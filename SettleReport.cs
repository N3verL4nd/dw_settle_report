using iTextSharp.text.pdf;
using Newtonsoft.Json;
using OfficeOpenXml;
using SettleReport.Dto;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;


namespace SettleReport
{
    public partial class SettleReportForm : Form
    {

        private string ybbm;

        // 地纬数据库
        private string connectionString = "User Id=账号;Password=密码;Data Source=地纬数据库IP/ORCL";


        private List<PayDetailZy> zyPatientNoList;
        private List<PayDetailMz> mzSettleNoList;

        public SettleReportForm()
        {
            InitializeComponent();

            zyPatientNoList = new List<PayDetailZy>();
            mzSettleNoList = new List<PayDetailMz>();
        }

        private bool LoginCheck()
        {
            if (Environment.MachineName.ToLower() == "pc-lgh")
            {
                return true;
            }
            using (PasswordForm passwordForm = new PasswordForm())
            {
                if (passwordForm.ShowDialog() == DialogResult.OK)
                {
                    string password = passwordForm.Password;

                    if ("admin".Equals(password))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        protected override void OnLoad(EventArgs e)
        {
            // 登录校验
            if (!LoginCheck())
            {
                MessageBox.Show("密码有误，退出！！！");
                this.Close();
            }

            string resp = Dw.Login();
            if (string.IsNullOrEmpty(resp))
            {
                MessageBox.Show("登录失败！！！");
                return;
            }

            LoginResp loginResp = JsonConvert.DeserializeObject<LoginResp>(resp);
            if (loginResp.resultcode != 0)
            {
                MessageBox.Show("登录失败, code: " + loginResp.resultcode);
                return;
            }
            ybbm = loginResp.resulttext;
        }

        private void MzX_KeyPress(object sender, KeyPressEventArgs e)
        {
            // 检查是否是数字或控制键
            if (!char.IsDigit(e.KeyChar))
            {
                // 不是数字或控制键，取消输入
                e.Handled = true;
            }
        }

        private void MzY_KeyPress(object sender, KeyPressEventArgs e)
        {
            // 检查是否是数字或控制键
            if (!char.IsDigit(e.KeyChar))
            {
                // 不是数字或控制键，取消输入
                e.Handled = true;
            }
        }

        private void ZyX_KeyPress(object sender, KeyPressEventArgs e)
        {
            // 检查是否是数字或控制键
            if (!char.IsDigit(e.KeyChar))
            {
                // 不是数字或控制键，取消输入
                e.Handled = true;
            }
        }

        private void ZyY_KeyPress(object sender, KeyPressEventArgs e)
        {
            // 检查是否是数字或控制键
            if (!char.IsDigit(e.KeyChar))
            {
                // 不是数字或控制键，取消输入
                e.Handled = true;
            }
        }

        private void MzSearchBtn_Click(object sender, EventArgs e)
        {
            string settleId = mzTextBox.Text;
            if (string.IsNullOrEmpty(settleId))
            {
                MessageBox.Show("请填写门诊结算号！！！");
                return;
            }
            Dictionary<string, string> param = new Dictionary<string, string>();
            param.Add("p_jshid", settleId);

            string resp = Dw.PrintJsd("print_jsd", ybbm, JsonConvert.SerializeObject(param));

            PdfResp pdfResp = JsonConvert.DeserializeObject<PdfResp>(resp);
            if (pdfResp.resultcode == 0)
            {
                byte[] buffer = Convert.FromBase64String(pdfResp.report);
                if (!mzCheckBox.Checked)
                {
                    string filePath = Path.Combine(Path.GetTempPath(), $"{Guid.NewGuid()}.pdf");
                    File.WriteAllBytes(filePath, buffer);

                    Process.Start(new ProcessStartInfo
                    {
                        FileName = filePath,
                        UseShellExecute = true
                    });
                    return;
                }

                if (SignTextBox.Text == null || SignTextBox.Text == "")
                {
                    MessageBox.Show("请选择签章图片！！！");
                    return;
                }

                string outputPdf = Path.Combine(Path.GetTempPath(), $"{Guid.NewGuid()}.pdf");
                using (FileStream outputPdfStream = new FileStream(outputPdf, FileMode.Create, FileAccess.Write))
                {
                    // 创建PdfReader对象
                    PdfReader reader = new PdfReader(buffer);

                    // 创建PdfStamper对象
                    PdfStamper stamper = new PdfStamper(reader, outputPdfStream);

                    // 获取签章图片
                    iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(SignTextBox.Text);

                    // 设置签章大小
                    image.ScaleToFit(float.Parse(signWidth.Text), float.Parse(signWidth.Text)); 

                    // 遍历每一页，添加签章
                    for (int i = 1; i <= reader.NumberOfPages; i++)
                    {
                        // 获取当前页面内容
                        PdfContentByte content = stamper.GetOverContent(i);

                        // 设置图片位置
                        image.SetAbsolutePosition(float.Parse(mzX.Text), reader.GetPageSizeWithRotation(i).Height - image.ScaledHeight - float.Parse(mzY.Text));

                        // 添加签章图片到页面
                        content.AddImage(image);
                    }

                    // 关闭PdfStamper和PdfReader
                    stamper.Close();
                    reader.Close();
                }

                Process.Start(new ProcessStartInfo
                {
                    FileName = outputPdf,
                    UseShellExecute = true
                });
            } 
            else
            {
                MessageBox.Show(JsonConvert.SerializeObject(pdfResp, Formatting.Indented));
            }
        }

        private void MzInbtn_Click(object sender, EventArgs e)
        {
            mzSettleNoList.Clear();
            string filePath = "";
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                // 设置对话框的标题
                openFileDialog.Title = "请选择待签章 Excel 文件";

                // 仅允许选择 Excel 文件
                openFileDialog.Filter = "Excel 文件 (*.xlsx)|*.xlsx|所有文件 (*.*)|*.*";

                // 打开文件选择对话框
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // 获取所选文件的路径
                    filePath = openFileDialog.FileName;
                }
            }

            using (ExcelPackage package = new ExcelPackage(filePath))
            {
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

                if (package.Workbook.Worksheets.Count <= 0)
                {
                    MessageBox.Show("未找到表，请确保 Excel 格式为 .xlsx");
                    return;
                }

                // 选取第一个表
                ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                Console.WriteLine($"Reading worksheet: {worksheet.Name}");

                MessageBox.Show($"存在 [{string.Join(", ", package.Workbook.Worksheets.Select(p => p.Name).ToArray())}] 表，默认选择 [{worksheet.Name}] 表");

               

                int rowCount = worksheet.Dimension.Rows;
                int colCount = worksheet.Dimension.Columns;

                // 读取标题行
                int headerRow = 1;

                Dictionary<string, int> columnIndices = new Dictionary<string, int>();

                for (int col = 1; col <= colCount; col++)
                {
                    object columnNameObj = worksheet.Cells[headerRow, col].Value;
                    if (columnNameObj != null)
                    {
                        string columnName = columnNameObj.ToString();
                        columnIndices[columnName] = col;
                    }
                }
                if (!columnIndices.ContainsKey("结算号") || !columnIndices.ContainsKey("姓名") )
                {
                    MessageBox.Show($"表: {worksheet.Name} 不包含【结算号】或者【姓名】列");
                    return;
                }

                // 从 headerRow + 1 行开始，跳过标题行
                for (int row = headerRow + 1; row <= rowCount; row++)
                {
                    PayDetailMz payDetail = new PayDetailMz
                    {
                        SettleNo = worksheet.Cells[row, columnIndices["结算号"]].Text?.ToString() ?? string.Empty,
                        Name = worksheet.Cells[row, columnIndices["姓名"]].Text?.ToString() ?? string.Empty,
                        RowIndex = row
                    };

                    mzSettleNoList.Add(payDetail);
                }

                MessageBox.Show("本次导入 " + mzSettleNoList.Count + " 条门诊记录");
            }
        }

        private void MzSignBtn_Click(object sender, EventArgs e)
        {
            if (mzSettleNoList == null || mzSettleNoList.Count <= 0)
            {
                MessageBox.Show("请先导入门诊数据！！！");
                return;
            }

            if (string.IsNullOrEmpty(SignTextBox.Text))
            {
                MessageBox.Show("请选择签章图片！！！");
                return;
            }

            string folderPath = "";
            using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
            {
                // 设置对话框的描述
                folderBrowserDialog.Description = "请选择导出文件夹位置";

                // 设置初始选定的文件夹（可选）
                folderBrowserDialog.SelectedPath = Path.GetDirectoryName(Environment.GetFolderPath(Environment.SpecialFolder.Desktop));

                // 显示文件夹选择对话框
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    // 获取所选的文件夹路径
                    folderPath = folderBrowserDialog.SelectedPath;
                }
            }

            if (string.IsNullOrEmpty(folderPath))
            {
                MessageBox.Show("请选择导出文件夹位置！！！");
                return;
            }

            using (WaitForm waitForm = new WaitForm(delegate () { Parallel.ForEach(mzSettleNoList, new ParallelOptions { MaxDegreeOfParallelism = 20 }, item => { ProcessMzReport(item, folderPath); }); }))
            {
                waitForm.ShowDialog(this);
            }
            MessageBox.Show("签章完毕，请自行判断缺失结算单！！！");
        }

        private void ProcessMzReport(PayDetailMz item, string folderPath)
        {
            if (string.IsNullOrEmpty(item.SettleNo))
            {
                return;
            }

            Dictionary<string, string> param = new Dictionary<string, string>();
            param.Add("p_jshid", item.SettleNo);

            string resp = Dw.PrintJsd("print_jsd", ybbm, JsonConvert.SerializeObject(param));
            if (string.IsNullOrEmpty(resp))
            {
                return;
            }

            PdfResp pdfResp = JsonConvert.DeserializeObject<PdfResp>(resp);
            if (pdfResp.resultcode == 0)
            {
                byte[] buffer = Convert.FromBase64String(pdfResp.report);

                string outputPdf = Path.Combine(folderPath, item.RowIndex + "-" + item.Name + ".pdf");
                using (FileStream outputPdfStream = new FileStream(outputPdf, FileMode.Create, FileAccess.Write))
                {
                    // 创建PdfReader对象
                    PdfReader reader = new PdfReader(buffer);

                    // 创建PdfStamper对象
                    PdfStamper stamper = new PdfStamper(reader, outputPdfStream);

                    // 获取签章图片
                    iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(SignTextBox.Text);

                    // 设置图片位置和大小
                    image.ScaleToFit(float.Parse(signWidth.Text), float.Parse(signWidth.Text)); // 设置签章大小

                    // 遍历每一页，添加签章
                    for (int i = 1; i <= reader.NumberOfPages; i++)
                    {
                        // 获取当前页面内容
                        PdfContentByte content = stamper.GetOverContent(i);

                        // 设置图片位置
                        image.SetAbsolutePosition(float.Parse(mzX.Text), reader.GetPageSizeWithRotation(i).Height - image.ScaledHeight - float.Parse(mzY.Text));

                        // 添加签章图片到页面
                        content.AddImage(image);
                    }

                    // 关闭PdfStamper和PdfReader
                    stamper.Close();
                    reader.Close();
                }
            }
        }

        private void ProcessZyReport(PayDetailZy item, string folderPath)
        {
            if (string.IsNullOrEmpty(item.InpatientNo))
            {
                return;
            }

            Dictionary<string, string> param = new Dictionary<string, string>();
            param.Add("p_blh", item.InpatientNo);

            string resp = Dw.PrintJsd("print_cyd", ybbm, JsonConvert.SerializeObject(param));
            if (string.IsNullOrEmpty(resp))
            {
                return;
            }

            PdfResp pdfResp = JsonConvert.DeserializeObject<PdfResp>(resp);
            if (pdfResp.resultcode == 0)
            {
                byte[] buffer = Convert.FromBase64String(pdfResp.report);

                // 文件名 Excel表名+序号
                string outputPdf = Path.Combine(folderPath, item.RowIndex+ "-" + item.Name + ".pdf");
                using (FileStream outputPdfStream = new FileStream(outputPdf, FileMode.Create, FileAccess.Write))
                {
                    // 创建PdfReader对象
                    PdfReader reader = new PdfReader(buffer);

                    // 创建PdfStamper对象
                    PdfStamper stamper = new PdfStamper(reader, outputPdfStream);

                    // 获取签章图片
                    iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(SignTextBox.Text);

                    // 设置图片位置和大小
                    image.ScaleToFit(float.Parse(signWidth.Text), float.Parse(signWidth.Text)); // 设置签章大小

                    // 遍历每一页，添加签章
                    for (int i = 1; i <= reader.NumberOfPages; i++)
                    {
                        // 获取当前页面内容
                        PdfContentByte content = stamper.GetOverContent(i);

                        // 设置图片位置
                        image.SetAbsolutePosition(float.Parse(zyX.Text), reader.GetPageSizeWithRotation(i).Height - image.ScaledHeight - float.Parse(zyY.Text));

                        // 添加签章图片到页面
                        content.AddImage(image);
                    }

                    // 关闭PdfStamper和PdfReader
                    stamper.Close();
                    reader.Close();
                }
            }
        }

        private void ZyInbtn_Click(object sender, EventArgs e)
        {
            zyPatientNoList.Clear();
            string filePath = "";
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                // 设置对话框的标题
                openFileDialog.Title = "请选择待签章 Excel 文件";

                // 仅允许选择 Excel 文件
                openFileDialog.Filter = "Excel 文件 (*.xlsx)|*.xlsx|所有文件 (*.*)|*.*";

                // 打开文件选择对话框
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // 获取所选文件的路径
                    filePath = openFileDialog.FileName;
                }
            }

            if (filePath == null || filePath == "")
            {
                MessageBox.Show("请选择一个 Excel 文件！！！");
                return;
            }

            using (ExcelPackage package = new ExcelPackage(filePath))
            {
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

                // 选取第一个表
                ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                Console.WriteLine($"Reading worksheet: {worksheet.Name}");

                MessageBox.Show($"存在 [{string.Join(", ", package.Workbook.Worksheets.Select(p => p.Name).ToArray())}] 表，默认选择 [{worksheet.Name}] 表");

                int rowCount = worksheet.Dimension.Rows;
                int colCount = worksheet.Dimension.Columns;

                // 读取标题行
                int headerRow = 1;

                Dictionary<string, int> columnIndices = new Dictionary<string, int>();

                for (int col = 1; col <= colCount; col++)
                {
                    object columnNameObj = worksheet.Cells[headerRow, col].Value;
                    if (columnNameObj != null)
                    {
                        string columnName = columnNameObj.ToString();
                        columnIndices[columnName] = col;
                    }
                }
                if (!columnIndices.ContainsKey("住院号") || !columnIndices.ContainsKey("姓名"))
                {
                    MessageBox.Show($"表: {worksheet.Name} 不包含【住院号】或者【姓名】列");
                    return;
                }

                // 从 headerRow + 1 行开始，跳过标题行
                for (int row = headerRow + 1; row <= rowCount; row++)
                {
                    PayDetailZy payDetail = new PayDetailZy
                    {
                        InpatientNo = worksheet.Cells[row, columnIndices["住院号"]].Text?.ToString().Split('-')[0] ?? string.Empty,
                        Name = worksheet.Cells[row, columnIndices["姓名"]].Text?.ToString() ?? string.Empty,
                        RowIndex = row
                    };
                    zyPatientNoList.Add(payDetail);
                }

                MessageBox.Show("本次导入 " + zyPatientNoList.Count + " 条住院记录");
            }
        }

        private void ZySignBtn_Click(object sender, EventArgs e)
        {
            if (zyPatientNoList == null || zyPatientNoList.Count <= 0)
            {
                MessageBox.Show("请先导入住院数据！！！");
                return;
            }

            string folderPath = "";
            using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
            {
                // 设置对话框的描述
                folderBrowserDialog.Description = "请选择一个文件夹";

                // 设置初始选定的文件夹（可选）
                folderBrowserDialog.SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

                // 显示文件夹选择对话框
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    // 获取所选的文件夹路径
                    folderPath = folderBrowserDialog.SelectedPath;
                }
            }

            if (string.IsNullOrEmpty(folderPath))
            {
                MessageBox.Show("请选择导出文件夹位置！！！");
                return;
            }

            using (WaitForm waitForm = new WaitForm(delegate () { Parallel.ForEach(zyPatientNoList, new ParallelOptions { MaxDegreeOfParallelism = 20 }, item => { ProcessZyReport(item, folderPath); }); }))
            {
                waitForm.ShowDialog(this);
            }

            MessageBox.Show("签章完毕，请自行判断缺失结算单！！！");
        }

        private void SignTextBox_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                openFileDialog.Filter = "Image Files|*.bmp;*.jpg;*.jpeg;*.png;*.gif";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    SignTextBox.Text = openFileDialog.FileName;
                }
            }

            if (string.IsNullOrEmpty(SignTextBox.Text))
            {
                MessageBox.Show("请选择签章图片！！！");
            }
        }

        private void Label11_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                openFileDialog.Filter = "Image Files|*.bmp;*.jpg;*.jpeg;*.png;*.gif";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    SignTextBox.Text = openFileDialog.FileName;
                }
            }

            if (string.IsNullOrEmpty(SignTextBox.Text))
            {
                MessageBox.Show("请选择签章图片！！！");
            }
        }

        private void ZySearchBtn_Click(object sender, EventArgs e)
        {
            string patientNo = zyTextBox.Text;
            if (string.IsNullOrEmpty(patientNo))
            {
                MessageBox.Show("请填写住院号！！！");
                return;
            }
            Dictionary<string, string> param = new Dictionary<string, string>();
            param.Add("p_blh", patientNo);


            string resp = Dw.PrintJsd("print_cyd", ybbm, JsonConvert.SerializeObject(param));

            PdfResp pdfResp = JsonConvert.DeserializeObject<PdfResp>(resp);


            if (pdfResp.resultcode == 0)
            {
                byte[] buffer = Convert.FromBase64String(pdfResp.report);
                if (!zyCheckBox.Checked)
                {
                    string tempDirectory = Path.GetTempPath();
                    string fileName = $"{Guid.NewGuid()}.pdf";
                    string filePath = Path.Combine(tempDirectory, fileName);

                    File.WriteAllBytes(filePath, buffer);

                    Process.Start(new ProcessStartInfo
                    {
                        FileName = filePath,
                        UseShellExecute = true
                    });
                    return;
                }

                if (SignTextBox.Text == null || SignTextBox.Text == "")
                {
                    MessageBox.Show("请选择签章图片！！！");
                    return;
                }

                string outputPdf = Path.Combine(Path.GetTempPath(), $"{Guid.NewGuid()}.pdf");
                using (FileStream outputPdfStream = new FileStream(outputPdf, FileMode.Create, FileAccess.Write))
                {
                    // 创建PdfReader对象
                    PdfReader reader = new PdfReader(buffer);

                    // 创建PdfStamper对象
                    PdfStamper stamper = new PdfStamper(reader, outputPdfStream);

                    // 获取签章图片
                    iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(SignTextBox.Text);

                    // 设置签章大小
                    image.ScaleToFit(float.Parse(signWidth.Text), float.Parse(signWidth.Text));


                    // 遍历每一页，添加签章
                    for (int i = 1; i <= reader.NumberOfPages; i++)
                    {
                        // 获取当前页面内容
                        PdfContentByte content = stamper.GetOverContent(i);

                        // 设置图片位置
                        image.SetAbsolutePosition(float.Parse(zyX.Text), reader.GetPageSizeWithRotation(i).Height - image.ScaledHeight - float.Parse(zyY.Text));

                        // 添加签章图片到页面
                        content.AddImage(image);
                    }

                    // 关闭PdfStamper和PdfReader
                    stamper.Close();
                    reader.Close();
                }
                Process.Start(new ProcessStartInfo
                {
                    FileName = outputPdf,
                    UseShellExecute = true
                });
            }
            else
            {
                MessageBox.Show(JsonConvert.SerializeObject(pdfResp, Formatting.Indented));
            }
        }

        private void SignWidth_KeyPress(object sender, KeyPressEventArgs e)
        {
            // 检查是否是数字或控制键
            if (!char.IsDigit(e.KeyChar))
            {
                // 不是数字或控制键，取消输入
                e.Handled = true;
            }
        }

        private void FillSettleIdButton_Click(object sender, EventArgs e)
        {
            string filePath = "";
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                // 设置对话框的标题
                openFileDialog.Title = "请选择要填充的 Excel 文件";

                // 仅允许选择 Excel 文件
                openFileDialog.Filter = "Excel 文件 (*.xlsx)|*.xlsx|所有文件 (*.*)|*.*";

                // 打开文件选择对话框
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // 获取所选文件的路径
                    filePath = openFileDialog.FileName;
                }
            }

            using (ExcelPackage package = new ExcelPackage(filePath))
            {
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

                if (package.Workbook.Worksheets.Count <= 0)
                {
                    MessageBox.Show("未找到表，请确保 Excel 格式为 .xlsx");
                    return;
                }

                // 选取第一个表
                ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                Console.WriteLine($"Reading worksheet: {worksheet.Name}");

                MessageBox.Show($"存在 [{string.Join(", ", package.Workbook.Worksheets.Select(p => p.Name).ToArray())}] 表，默认选择 [{worksheet.Name}] 表");


                // 行数
                int rowCount = worksheet.Dimension.Rows;
                // 列数
                int colCount = worksheet.Dimension.Columns;

                // 读取标题行
                int headerRow = 1;

                // 获取最后一列的索引
                int lastColumnIndex = worksheet.Dimension.End.Column;

                Dictionary<string, int> columnIndices = new Dictionary<string, int>();

                for (int col = 1; col <= colCount; col++)
                {
                    object columnNameObj = worksheet.Cells[headerRow, col].Value;
                    if (columnNameObj != null)
                    {
                        string columnName = columnNameObj.ToString();
                        columnIndices[columnName] = col;
                    }
                }

                if (columnIndices.ContainsKey("结算号"))
                {
                    MessageBox.Show($"表: {worksheet.Name} 已经包含【结算号】列");
                    return;
                }

                if (!columnIndices.ContainsKey("住院流水号"))
                {
                    MessageBox.Show($"表: {worksheet.Name} 不包含【住院流水号】列");
                    return;
                }

                // 新增一列保存结算号
                worksheet.Cells[headerRow, lastColumnIndex + 1].Value = "结算号";

                // 从 headerRow + 1 行开始，跳过标题行
                for (int row = headerRow + 1; row <= rowCount; row++)
                {
                    string zyLsh = worksheet.Cells[row, columnIndices["住院流水号"]].Text;
                    if (string.IsNullOrEmpty(zyLsh))
                    {
                        continue;
                    }

                    using (var connection = new OracleConnection(connectionString))
                    {
                        connection.Open();

                        // 查询Oracle数据库
                        string query = "select b.jshid from mhs5.patient_settle_genl b where b.zylsh = :value";
                        using (var command = new OracleCommand(query, connection))
                        {
                            command.Parameters.Add(new OracleParameter("value", zyLsh));

                            using (var reader = command.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    var jshId = reader["JSHID"].ToString();
                                    worksheet.Cells[row, lastColumnIndex+1].Value = jshId;
                                }
                            }
                        }
                    }
                }
                // 保存修改后的Excel文件
                package.Save();
                MessageBox.Show("填充结算号完成！！！");
            }
        }
    }
}
