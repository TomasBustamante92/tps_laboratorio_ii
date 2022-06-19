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

        /// <summary>
        /// Agrega un objeto a la lista si este no se encuentra ya en esta
        /// </summary>
        /// <param name="obj">objeto a agregar</param>
        /// <returns>true si pudo agregarlo, caso contrario false</returns>
        public bool Agregar(T obj)
        {
            if(obj is not null && !EstaEnLista(obj))
            {
                this.lista.Add(obj);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Busca en la lista si se encuentra el objeto pasado por parametro
        /// </summary>
        /// <param name="obj">objeto a buscar en lista</param>
        /// <returns>true si lo encuentra, caso contrario false</returns>
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

        /// <summary>
        /// Guarda la lista en un archivo xml
        /// </summary>
        /// <param name="path">Lugar donde se guarda la lista</param>
        /// <param name="nombreArchivo">nombre del archivo sin extensión</param>
        public void GuardarListaXml(string path, string nombreArchivo)
        {
            using(StreamWriter writer = new StreamWriter(path + $"\\{nombreArchivo}.xml"))
            {
                XmlSerializer serializer = new XmlSerializer(this.lista.GetType());
                serializer.Serialize(writer, this.lista);
            }
        }

        /// <summary>
        /// Carga la lista de un archivo xml, de no encontrarlo devuelve ArchivoNoEncontradoException
        /// </summary>
        /// <param name="path">Lugar donde se lee el archivo xml</param>
        /// <param name="nombreArchivo">nombre del archivo sin extensión</param>
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
                throw new ArchivoNoEncontradoException();
            }
        }

        /// <summary>
        /// Guarda la lista en un archivo json
        /// </summary>
        /// <param name="path">Lugar donde se guarda la lista</param>
        /// <param name="nombreArchivo">nombre del archivo sin extensión</param>
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

        /// <summary>
        /// Carga la lista de un archivo json, de no encontrarlo devuelve ArchivoNoEncontradoException
        /// </summary>
        /// <param name="path">Lugar donde se lee el archivo json</param>
        /// <param name="nombreArchivo">nombre del archivo sin extensión</param>
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
                throw new ArchivoNoEncontradoException();
            }
        }
    }
}
