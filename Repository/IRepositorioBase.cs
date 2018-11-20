using Entities.Models;
using Entities.Models.Catalogos;
using Entities.Models.Extras;
using Entities.Models.Masterfiles;
using Entities.Models.Paquetes;
using Entities.Models.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IRepositorioBase<T> where T : class
    {
        Task<T> GetByIdAsync(int id);

        Task<IEnumerable<T>> GetAllAsyc();

        Task<List<T>> FindAsyc(Expression<Func<T, bool>> predicado);

        Task<T> AddAsync(T entity);

        Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities);

        void Remove(T entity);

        void RemoveRange(IEnumerable<T> entities);

        T Update(T entity);

    }


    public interface IRepositorioAgenda : IRepositorioBase<Agenda>
    {
        Task<IEnumerable<Agenda>> GetFechasByMes(int hotel, int anio, int mes);
        
    }

    public interface IRepositorioHotel : IRepositorioBase<Hotel>
    {
    }

    //public interface IRepositorioEjecutivo : IRepositorioBase<Ejecutivo>
    //{
    //}

    //public interface IRepositorioCoordinador : IRepositorioBase<Coordinador>
    //{
    //}

    public interface IRepositorioUsarioHotel : IRepositorioBase<UsuarioHotel>
    {

    }


    public interface IRepositorioLugarCena : IRepositorioBase<LugarCena>
    {
        Task<LugarCena> GetLugarCenaConHotelByIdAsync(int id);
        Task<IEnumerable<LugarCena>> GetLugarCenaConHotelAsync();



    }

    public interface IRepositorioLugarCeremonia : IRepositorioBase<LugarCeremonia>
    {

    }

    public interface IRepositorioBackUp : IRepositorioBase<BackUp>
    {
    }

    public interface IRepositorioHoras : IRepositorioBase<Horas>
    {
    }

    public interface IRepositorioTipoCeremonia : IRepositorioBase<TipoCeremonia>
    {
    }

    public interface IRepositorioAgencia : IRepositorioBase<Agencia>
    {
    }

    public interface IRepositorioTtoo : IRepositorioBase<Ttoo>
    {
    }

    public interface IRepositorioDiasBloqueados : IRepositorioBase<DiasBloqueados>
    {
        Task<IEnumerable<DiasBloqueados>> GetFechasByMes(int hotel, int anio, int mes);
    }

    public interface IRepositorioComentario : IRepositorioBase<Comentario>
    {
    }

    public interface IRepositorioHistorial : IRepositorioBase<Historial>
    {
    }

    public interface IRepositorioMasterFile : IRepositorioBase<MasterFile>
    {
    }

    public interface IRepositorioMasterFileContent : IRepositorioBase<MasterFileContent>
    {
        Task<IEnumerable<MasterFileContent>> GetContenido(int mfid);
        Task<MasterFileContent> GetContenidoById(int id);
    }

    public interface IRepositorioPaquete : IRepositorioBase<Paquete>
    {
    }

    public interface IRepositorioServicio : IRepositorioBase<Servicio>
    {
        Task<IEnumerable<Servicio>> GetServicioInclude(int h);
    }

    public interface IRepositorioPaqueteServicio : IRepositorioBase<PaqueteServicio>
    {
    }

    public interface IRepositorioCategoria : IRepositorioBase<Categoria>
    {
    }

    public interface IRepositorioDepartamento : IRepositorioBase<Departamento>
    {
    }

    public interface IRepositorioDepartamentoServicio : IRepositorioBase<DepartamentoServicio>
    {
    }

    public interface IRepositorioUsuario : IRepositorioBase<Usuario>
    {
    }

    public interface IRepositorioRole : IRepositorioBase<Role>
    {
    }

    public interface IRepositorioDivisa : IRepositorioBase<Divisa>
    {

    }

}
