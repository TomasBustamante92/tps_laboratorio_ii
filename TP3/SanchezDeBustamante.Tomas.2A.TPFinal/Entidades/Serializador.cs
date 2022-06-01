using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Entidades
{
    public class Serializador<T>
    {
        List<T> lista;

        public Serializador()
        {
            this.lista = new List<T>();
        }

        public List<T> Lista
        {
            get { return this.lista; }
            set { this.lista = value; }
        }

        public bool Agregar(T obj)
        {
            if(obj is not null)
            {
                if(!EstaEnLista(obj))
                {
                    this.lista.Add(obj);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                throw new NullReferenceException();
            }
        }

        public bool Eliminar(T obj)
        {
            if (obj is not null)
            {
                if(EstaEnLista(obj))
                {
                    this.lista.Remove(obj);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                throw new NullReferenceException();
            }
        }

        bool EstaEnLista(T obj)
        {
            if(obj is not int)
            {
                foreach (T item in this.lista)
                {
                    if (obj.Equals(item))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public void GuardarListaXml(string path, string nombreArchivo)
        {
            using(StreamWriter writer = new StreamWriter(path + $"\\{nombreArchivo}.xml"))
            {
                XmlSerializer serializer = new XmlSerializer(this.lista.GetType());
                serializer.Serialize(writer, this.lista);
            }
        }

        public void CargarListaXml(string path, string nombreArchivo)
        {
            string pathCompleto = path + $"\\{nombreArchivo}.xml";
            if (File.Exists(pathCompleto))
            {
                using (StreamReader reader = new StreamReader(pathCompleto))
                {
                    XmlSerializer serializer = new XmlSerializer(this.lista.GetType());
                    this.lista = serializer.Deserialize(reader) as List<T>;
                }
            }
            else
            {
                throw new Exception(); //INVENTAR ALGO
            }
        }

        public void GuardarListaJson(string path, string nombreArchivo)
        {
            using (StreamWriter writer = new StreamWriter(path + $"\\{nombreArchivo}.json"))
            {
                JsonSerializerOptions options = new JsonSerializerOptions();
                options.WriteIndented = true;
                string serializer = JsonSerializer.Serialize(this.lista, options);
                writer.WriteLine(serializer);
            }
        }

        public void CargarListaJson(string path, string nombreArchivo)
        {
            string pathCompleto = path + $"\\{nombreArchivo}.json";
            if (File.Exists(pathCompleto))
            {
                using (StreamReader reader = new StreamReader(pathCompleto))
                {
                    string serializer = reader.ReadToEnd();
                    this.lista = JsonSerializer.Deserialize<List<T>>(serializer);
                }
            }
            else
            {
                throw new Exception(); //INVENTAR ALGO
            }
        }
    }
}
