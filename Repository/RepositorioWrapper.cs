using Entities.Contexts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class RepositorioWrapper : IRepositorioWrapper
    {
        AppDbContext _Context { get; }

        public RepositorioWrapper(AppDbContext context)
        {
            _Context = context;

            Agendas = new RepositorioAgenda(_Context);
            Hoteles = new RepositorioHotel(_Context);
            //Ejecutivos = new RepositorioEjecutivo(_Context);
            //Coordinadores = new RepositorioCoordinador(_Context);
            UsuarioHotel = new RepositorioUsuarioHotel(_Context);
            LugaresCena = new RepositorioLugarCena(_Context);
            LugaresCeremonia = new RepositorioLugarCeremonia(_Context);
            BackUps = new RepositorioBackUp(_Context);
            Horas = new RepositorioHoras(_Context);
            TiposCeremonia = new RepositorioTipoCeremonia(_Context);
            Agencias = new RepositorioAgencia(_Context);
            Ttoos = new RepositorioTtoo(_Context);
            DiasBloqueados = new RepositorioDiasBloqueados(_Context);
            Comentarios = new RepositorioComentario(_Context);
            Historial = new RepositorioHistorial(_Context);
            MasterFile = new RepositorioMasterFile(_Context);
            MasterFileContent = new RepositorioMasterFileContent(_Context);
            Paquetes = new RepositorioPaquete(_Context);
            Servicios = new RepositorioServicio(_Context);
            PaquetesServicios = new RepositorioPaqueteServicio(_Context);
            Categorias = new RepositorioCategoria(_Context);
            Usuarios = new RepositorioUsuario(_Context);
            Roles = new RepositorioRole(_Context);
            Divisas = new RepositorioDivisa(_Context);



        }
        public IRepositorioAgenda Agendas { get; private set; }
        public IRepositorioHotel Hoteles { get; private set; }
        //public IRepositorioEjecutivo Ejecutivos { get; private set; }
        //public IRepositorioCoordinador Coordinadores { get; private set; }
        public IRepositorioUsarioHotel UsuarioHotel { get; private set; }
        public IRepositorioLugarCena LugaresCena { get; private set; }
        public IRepositorioLugarCeremonia LugaresCeremonia { get; private set; }
        public IRepositorioBackUp BackUps { get; private set; }
        public IRepositorioHoras Horas { get; private set; }
        public IRepositorioTipoCeremonia TiposCeremonia { get; private set; }
        public IRepositorioAgencia Agencias { get; private set; }
        public IRepositorioTtoo Ttoos { get; private set; }
        public IRepositorioDiasBloqueados DiasBloqueados { get; private set; }
        public IRepositorioComentario Comentarios { get; private set; }
        public IRepositorioHistorial Historial { get; private set; }
        public IRepositorioMasterFile MasterFile { get; private set; }
        public IRepositorioMasterFileContent MasterFileContent { get; private set; }
        public IRepositorioPaquete Paquetes { get; private set; }
        public IRepositorioServicio Servicios { get; private set; }
        public IRepositorioPaqueteServicio PaquetesServicios { get; private set; }
        public IRepositorioCategoria Categorias { get; private set; }
        public IRepositorioUsuario Usuarios { get; private set; }
        public IRepositorioRole Roles { get; private set; }
        public IRepositorioDivisa Divisas { get; private set; }



        public async Task<int> CompleteAsync()
        {
            return await this._Context.SaveChangesAsync();
        }

        public void Dispose()
        {
            // liberar los recuros de memoria
            this._Context.Dispose();
        }

    }
}
