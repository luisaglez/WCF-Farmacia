using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCF_Final_
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IFarmacia" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IFarmacia
    {
        [OperationContract]
        void guardar(int a, string b, string c, int d, string e, float f);
        [OperationContract]
        bool borrar(int a);
        [OperationContract]
        string[] buscar(int fol);
        [OperationContract]
        bool editar( int a, string b, string c, int d, string e, float f);

    }
}
