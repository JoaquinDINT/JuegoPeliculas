using Azure.Storage.Blobs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegoPeliculas.servicio
{
    static class Nube
    {

        private static readonly string CADENA_CONEXION = "DefaultEndpointsProtocol=https;AccountName=actividad5;AccountKey=qp+y6Le7YroFngIEhxbDFHdUJPB/tRjMUvQaEzzSPOCee7lSdYz7GXXBUZ6cm2xEP8EmjxLHBrkenbaApNYneg==;EndpointSuffix=core.windows.net"; //La obtenemos en el portal de Azure, asociada a la cuenta de almacenamiento
        private static readonly string NOMBRE_BLOB = "imgs"; //El nombre que le hayamos dado a nuestro contenedor de blobs en el portal de Azure

        public static string SubirImagen(string path)
        {
            //Cliente del contenedor
            BlobServiceClient clienteBlobService = new BlobServiceClient(CADENA_CONEXION);
            BlobContainerClient clienteContenedor = clienteBlobService.GetBlobContainerClient(NOMBRE_BLOB);

            //Leemos la imagen y la subimos al contenedor
            Stream streamImagen = File.OpenRead(path);
            string nombreImagen = Path.GetFileName(path);
            _ = clienteContenedor.UploadBlob(nombreImagen, streamImagen);

            //Una vez subida, obtenemos la URL para referenciarla
            BlobClient clienteBlobImagen = clienteContenedor.GetBlobClient(nombreImagen);

            return clienteBlobImagen.Uri.AbsoluteUri;
        }
    }
}
