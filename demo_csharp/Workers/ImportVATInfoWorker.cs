using Common;
using demo_csharp.Workers.IWorkService;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace demo_csharp.Workers
{
    public class ImportVATInfoWorker : IMasterWorker
    {
        public void Do()
        {
            string filePath = @"D:\workspace\guiyang\批量处理数据\增值税批量导入\20190416\汇总.csv";
            string tableName = "增值税用户信息补充_20190418";
            List<string> infos = new List<string>();

            using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.None))
            {
                StreamReader sr = new StreamReader(fs, System.Text.Encoding.Default);
                string str = string.Empty;
                while (str != null)
                {
                    str = sr.ReadLine();
                    if (string.IsNullOrEmpty(str))
                    {
                        break;
                    }

                    infos.Add(str);
                }
                sr.Close();
            }

            int totalCount = infos.Count;
            int stepSize = 500;
            int steps = totalCount / stepSize;
            int tail = totalCount % stepSize;

            MySqlHelper sqlHelper = MySqlHelper.CreateInstance();

            for (int index = 0; index < steps; index++)
            {
                StringBuilder sqlCommand = new StringBuilder(500);
                sqlCommand.Append("INSERT INTO ").Append(tableName).Append(" VALUES");
                for (int index_1 = index * stepSize; index_1 < (index + 1) * stepSize; index_1++)
                {
                    string[] infoDetail = infos[index_1].Split(',');
                    sqlCommand.Append("('").Append(infoDetail[0]).Append("',");
                    sqlCommand.Append("'").Append(infoDetail[1]).Append("',");
                    sqlCommand.Append("'").Append(infoDetail[2]).Append("',");
                    sqlCommand.Append("'").Append(infoDetail[3]).Append("',");
                    sqlCommand.Append("'").Append(infoDetail[4]).Append("',");
                    sqlCommand.Append("'").Append(infoDetail[5]).Append("',");
                    sqlCommand.Append("'").Append(infoDetail[6]).Append("'),");
                }

                sqlHelper.Insert(sqlCommand.ToString().Trim(','));
                Console.WriteLine(sqlCommand.ToString().Trim(','));
            }

            StringBuilder sqlCommand_tail = new StringBuilder(500);
            sqlCommand_tail.Append("INSERT INTO ").Append(tableName).Append(" VALUES");
            for (int index = stepSize * steps; index < totalCount; index++)
            {
                if (index > totalCount)
                {
                    break;
                }

                string[] infoDetail = infos[index].Split(',');
                sqlCommand_tail.Append("('").Append(infoDetail[0]).Append("',");
                sqlCommand_tail.Append("'").Append(infoDetail[1]).Append("',");
                sqlCommand_tail.Append("'").Append(infoDetail[2]).Append("',");
                sqlCommand_tail.Append("'").Append(infoDetail[3]).Append("',");
                sqlCommand_tail.Append("'").Append(infoDetail[4]).Append("',");
                sqlCommand_tail.Append("'").Append(infoDetail[5]).Append("',");
                sqlCommand_tail.Append("'").Append(infoDetail[6]).Append("'),");
            }

            sqlHelper.Insert(sqlCommand_tail.ToString().Trim(','));
            Console.WriteLine(sqlCommand_tail.ToString().Trim(','));
        }
    }
}
