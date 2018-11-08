using System;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
   public interface IRepositorioWrapper: IDisposable
    {
        IRepositorioAgenda Agendas { get; }
        IRepositorioHotel Hoteles { get; }
        //IRepositorioEjecutivo Ejecutivos { get; }
        //IRepositorioCoordinador Coordinadores { get; }
        IRepositorioUsarioHotel UsuarioHotel { get; }
        IRepositorioLugarCena LugaresCena { get; }
        IRepositorioLugarCeremonia LugaresCeremonia { get; }
        IRepositorioBackUp BackUps { get; }
        IRepositorioHoras Horas { get; }
        IRepositorioTipoCeremonia TiposCeremonia { get; }
        IRepositorioAgencia Agencias { get; }
        IRepositorioTtoo Ttoos { get; }
        IRepositorioDiasBloqueados DiasBloqueados { get; }
        IRepositorioComentario Comentarios { get; }
        IRepositorioHistorial Historial { get; }
        IRepositorioMasterFile MasterFile { get; }
        IRepositorioMasterFileContent MasterFileContent { get; }
        IRepositorioPaquete Paquetes { get; }
        IRepositorioServicio Servicios { get; }
        IRepositorioPaqueteServicio PaquetesServicios { get; }
        IRepositorioCategoria Categorias { get; }

        IRepositorioDepartamento Departamentos { get; }
        IRepositorioDepartamentoServicio DepartamentosServicio { get; }

        IRepositorioUsuario Usuarios { get; }
        IRepositorioRole Roles { get; }
        IRepositorioDivisa Divisas { get; }
        Task<int> CompleteAsync();
    }
}
