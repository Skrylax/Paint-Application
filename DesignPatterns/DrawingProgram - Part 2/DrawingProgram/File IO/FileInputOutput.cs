using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using DrawingProgram.Commands;

namespace DrawingProgram.File_IO
{
    class FileInputOutput
    {
        StreamReader streamReader;
        StreamWriter streamWriter;
        Stream file;

        public List<string[]> streamList;


        public FileInputOutput(Stream f)
        {
            file = f;
            streamList = new List<string[]>();
        }

        public void CreateList()
        {
            streamReader = new StreamReader(file);
            string line = streamReader.ReadLine();

            while (line != null)
            {
                string[] shape = line.Split(' ');
                streamList.Add(shape);
                line = streamReader.ReadLine();
            }
            streamReader.Close();
        }

        public void WriteFile(List<Shape> shapeList)
        {
            streamWriter = new StreamWriter(file);

            foreach(Shape s in shapeList)
            {
                streamWriter.WriteLine(s.ToString());
            }
            streamWriter.Close();
        }

        // Debug print code
        public void PrintShapes()
        {
            streamReader = new StreamReader(file);
            string line = streamReader.ReadLine();

            while (line != null)
            {
                Console.WriteLine(line);
                line = streamReader.ReadLine();
            }

            streamReader.Close();
        }
    }
}
