using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Xml.Schema;

namespace Assignment1
{

    class FirstAssignment
    { 

        public class ManageTeacherData
        {
            int iopt;
            FileStream fileStream;
            StreamWriter streamWriter;
            StreamReader streamReader;
            long id;
            string name;
            string classname;
            string section;
            string[] temp = null;
            bool res = false;
            string filepath = "C:\\Murali\\SimpliLearn\\Project\\MSTeachersData.txt";


            public ManageTeacherData()
            {
                if (!File.Exists(filepath))
                {
                    FileStream fileStream = new FileStream(filepath, FileMode.Create, FileAccess.Write);
                    streamWriter = new StreamWriter(fileStream);
                    streamWriter.WriteLine("==========================================================");
                    streamWriter.WriteLine("Teacher ID,Teacher Name,Teacher ClassName,Teacher Section");
                    streamWriter.WriteLine("=========================================================");
                    streamWriter.Close();
                    fileStream.Close();
                }

            }
            public void ManageTeacherDetails()
            {
                do
                {
                    Console.WriteLine("*~~~~~~~~~~~~~~* Welcome to Rainbow School*~~~~~~~~~~~~~~*");
                    Console.WriteLine("1. Add Teachers details");
                    Console.WriteLine("2. Get Teachers details");
                    Console.WriteLine("3. Modify Teachers details");
                    Console.WriteLine("4. Exit");
                    Console.Write("Please select options from Menu : ");
                    iopt = int.Parse(Console.ReadLine());
                    switch (iopt)
                    {
                        case 1:
                            AddTeachersdetails();
                            break;
                        case 2:
                            GetTeachersdetails();
                            break;
                        case 3:
                            ModifyTeachersdetails();
                            break;
                        case 4:
                            Console.WriteLine("*~~~~~~~~~~~~~~* Thank you !! *~~~~~~~~~~~~~~*");
                            break;
                    }
                } while (iopt != 4);
            }
            public void AddTeachersdetails()
            {
                fileStream = new FileStream(filepath, FileMode.Append, FileAccess.Write);
                streamWriter = new StreamWriter(fileStream);

                Console.Write("Enter Teacher Id : ");
                id = int.Parse(Console.ReadLine());
                Console.Write("Enter Teacher Name : ");
                name = Console.ReadLine();
                Console.Write("Enter Teacher Classname : ");
                classname = Console.ReadLine();
                Console.Write("Enter Teacher Section : ");
                section = Console.ReadLine();

                streamWriter.WriteLine($"{id},{name},{classname},{section}");

                streamWriter.Close();
                fileStream.Close();
            }

            public void GetTeachersdetails()
            {
                Console.Write("Enter Teacher id to Get the details : ");
                id = int.Parse(Console.ReadLine());

                fileStream = new FileStream(filepath, FileMode.Open, FileAccess.Read);
                streamReader = new StreamReader(fileStream);

                List<string> lines = new List<string>();
                while (!streamReader.EndOfStream)
                {
                    lines.Add(streamReader.ReadLine());
                }

                for (int iline = 3; iline < lines.Count; iline++)
                {
                    temp = lines[iline].Split(",");
                    if (id == int.Parse(temp[0]))
                    {
                        res = true;
                        break;
                    }

                }

                if (res)
                {
                    Console.WriteLine("~~~~~~~~~~~~~~Teacher Details ~~~~~~~~~~~~~~");
                    Console.WriteLine("Teacher Id : " + temp[0]);
                    Console.WriteLine("Teacher Name : " + temp[1]);
                    Console.WriteLine("Teacher ClassName : " + temp[2]);
                    Console.WriteLine("Teacher Section : " + temp[3]);
                    Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                }
                else
                {
                    Console.WriteLine("No records found");
                }
                streamReader.Close();
                fileStream.Close();

            }

            public void ModifyTeachersdetails()
            {

                Console.Write("Enter Teacher Id to modify : ");
                id = int.Parse(Console.ReadLine());


                fileStream = new FileStream(filepath, FileMode.Open, FileAccess.Read);
                streamReader = new StreamReader(fileStream);

                List<string> lines = new List<string>();
                while (!streamReader.EndOfStream)
                {
                    lines.Add(streamReader.ReadLine());
                }

                for (int iline = 3; iline < lines.Count; iline++)
                {
                    temp = lines[iline].Split(",");
                    if (id == int.Parse(temp[0]))
                    { 
                        Console.Write("Enter Teacher Name : ");
                        name = Console.ReadLine();
                        Console.Write("Enter Teacher Classname : ");
                        classname = Console.ReadLine();
                        Console.Write("Enter Teacher Section : ");
                        section = Console.ReadLine();
                        string newString = id + "," + name + "," + classname + "," + section;
                        lines[iline] = newString;
                        res = true;
                        break;
                    }

                }
                streamReader.Close();

                if (res)
                {
                    fileStream = new FileStream(filepath, FileMode.Open, FileAccess.Write);
                    streamWriter = new StreamWriter(fileStream);
                    for (int mline = 0; mline < lines.Count; mline++)
                    {
                        streamWriter.WriteLine(lines[mline]);
                    }
                }
                else
                {
                    Console.WriteLine("No records found");
                }
                streamWriter.Close();
                fileStream.Close();
            }

        }
        static void Main(string[] args)
        {
            ManageTeacherData teacherobj = new ManageTeacherData();
            teacherobj.ManageTeacherDetails();
        }
    }
}
