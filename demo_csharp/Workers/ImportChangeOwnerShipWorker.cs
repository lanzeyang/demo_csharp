using Common;
using demo_csharp.Workers.IWorkService;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo_csharp.Workers
{
    /// <summary>
    /// 导入过户数据
    /// </summary>
    public class ImportChangeOwnerShipWorker : IMasterWorker
    {
        public void Do()
        {
            string filePath = @"D:\workspace\guiyang\批量处理数据\批量过户\南明分公司2018年8-12月过户批量修改0308.csv";
            string tableName = "[南明批量过户_20190311]";
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
                    string cardId = string.Empty;
                    string oldCardName = string.Empty;
                    string newCardName = string.Empty;
                    string contact = string.Empty;

                    cardId = infoDetail[0];
                    oldCardName = infoDetail[1];
                    newCardName = infoDetail[2];

                    if (infoDetail.Length >= 4)
                    {
                        contact = infoDetail[3];
                    }

                    sqlCommand.Append("('").Append(cardId).Append("',");
                    sqlCommand.Append("'").Append(newCardName).Append("',");
                    sqlCommand.Append("'").Append(contact).Append("',");
                    sqlCommand.Append("'").Append(oldCardName).Append("'),");
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
                string cardId = string.Empty;
                string oldCardName = string.Empty;
                string newCardName = string.Empty;
                string contact = string.Empty;

                cardId = infoDetail[0];
                oldCardName = infoDetail[1];
                newCardName = infoDetail[2];

                if (infoDetail.Length >= 4)
                {
                    contact = infoDetail[3];
                }

                sqlCommand_tail.Append("('").Append(cardId).Append("',");
                sqlCommand_tail.Append("'").Append(newCardName).Append("',");
                sqlCommand_tail.Append("'").Append(contact).Append("',");
                sqlCommand_tail.Append("'").Append(oldCardName).Append("'),");
            }

            sqlHelper.Insert(sqlCommand_tail.ToString().Trim(','));
            Console.WriteLine(sqlCommand_tail.ToString().Trim(','));     
        }
    }
}
