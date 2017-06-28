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
        public StreamReader streamReader;
        public StreamWriter streamWriter;
        public Stream file;

        public List<string[]> streamList;


        public FileInputOutput(Stream file)
        {
            this.file = file;
            streamWriter = new StreamWriter(file);
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
                streamWriter.WriteLine(s.ToString(0));
            }
            streamWriter.Close();
        }

        public void CloseStreamWriter()
        {
            streamWriter.Close();
        }
    }
}
