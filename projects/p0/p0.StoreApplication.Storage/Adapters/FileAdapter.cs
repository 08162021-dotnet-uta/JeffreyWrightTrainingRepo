using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace p0.StoreApplication.Storage.Adapters
{
  public class FileAdapter
  {
    public List<T> ReadFromFile<T>(string path) where T : class
    {
      if (!File.Exists(path))
      {
        return null;
      }
      // open file
      var file = new StreamReader(path);
      // serialize object
      var xml = new XmlSerializer(typeof(List<T>));
      // read from file
      var result = xml.Deserialize(file) as List<T>;
      // close the file
      file.Close();
      // return data
      return result;
    }

    public void WriteToFile<T>(string path, List<T> data) where T : class
    {
      if(ReadFromFile<T>(path) == null)
      {
        Directory.CreateDirectory(path.Substring(0, path.LastIndexOf('\\')));
        File.CreateText(path);
      }
      // open file
      var file = new StreamWriter(path);
      // serialize object
      var xml = new XmlSerializer(typeof(List<T>));
      // write to file
      xml.Serialize(file, data);
      // close the file
      file.Close();
    }
  }
}