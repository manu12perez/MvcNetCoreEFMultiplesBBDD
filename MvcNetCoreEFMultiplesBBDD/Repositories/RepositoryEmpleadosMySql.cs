using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcNetCoreEFMultiplesBBDD.Data;
using MvcNetCoreEFMultiplesBBDD.Models;

/*
--MYSQL
create view V_EMPLEADOS as
select 
    EMP.EMP_NO as IDEMPLEADO, 
    EMP.APELLIDO, 
    EMP.OFICIO, 
    EMP.SALARIO, 
    DEPT.DNOMBRE as DEPARTAMENTO, 
    DEPT.LOC as LOCALIDAD
from EMP
inner join DEPT on EMP.DEPT_NO = DEPT.DEPT_NO;

*/

namespace MvcNetCoreEFMultiplesBBDD.Repositories
{
    public class RepositoryEmpleadosMySql : IRepositoryEmpleados
    {
        private HospitalContext context;

        public RepositoryEmpleadosMySql(HospitalContext context)
        {
            this.context = context;
        }

        public async Task<List<EmpleadoView>> GetEmpleadosAsync()
        {
            var consulta = from datos in this.context.EmpleadosView
                           select datos;

            return await consulta.ToListAsync();
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
