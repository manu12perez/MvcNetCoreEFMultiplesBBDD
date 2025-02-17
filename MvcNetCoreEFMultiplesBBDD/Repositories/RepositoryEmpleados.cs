using Microsoft.EntityFrameworkCore;
using MvcNetCoreEFMultiplesBBDD.Data;
using MvcNetCoreEFMultiplesBBDD.Models;

#region VISTAS Y PROCEDIMIENTOS ALMACENADOS SQL SERVER

/*
--SQL
create view V_EMPLEADOS
as
	select EMP_NO as IDEMPLEADO
	, EMP.APELLIDO, EMP.OFICIO, EMP.SALARIO
	, DEPT.DNOMBRE as DEPARTAMENTO
	, DEPT.LOC as LOCALIDAD
	from EMP
	inner join DEPT
	on EMP.DEPT_NO = DEPT.DEPT_NO
go

create procedure SP_ALL_VEMPLEADOS
as
	select * from V_EMPLEADOS
go

*/

#endregion

namespace MvcNetCoreEFMultiplesBBDD.Repositories
{
    public class RepositoryEmpleados: IRepositoryEmpleados
    {
        private HospitalContext context;

        public RepositoryEmpleados(HospitalContext context)
        {
            this.context = context;
        }

        public async Task<List<EmpleadoView>> GetEmpleadosAsync()
        {      
            string sql = "SP_ALL_VEMPLEADOS";
            var consulta = this.context.EmpleadosView.FromSqlRaw(sql);

            return await consulta.ToListAsync();

            //var consulta = from datos in this.context.EmpleadosView
            //               select datos;

            //return await consulta.ToListAsync();
        }

        public async Task<EmpleadoView> FindEmpleadoAsync(int idEmpleado)
        {
            var consulta = from datos in this.context.EmpleadosView
                           where datos.IdEmpleado == idEmpleado
                           select datos;

            return await consulta.FirstOrDefaultAsync();
        }
    }
}
