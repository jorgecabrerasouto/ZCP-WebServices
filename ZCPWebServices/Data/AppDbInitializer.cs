using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Threading.Tasks;
using ZCPWebServices.Data.Model;
using ZCPWebServices.Data.ViewModels.Authentication;

namespace ZCPWebServices.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using IServiceScope serviceScope = applicationBuilder.ApplicationServices.CreateScope();
            var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

            if (!context.Tickets.Any())
            {
                context.Tickets.AddRange(new Ticket()
                {
                    departamento = "LA GUAJIRA",
                    ejecutor = "CIBERC",
                    estado = "Cerrado",
                    //fechaCierre = DateTime.ParseExact("2024-06-24", "yyyy-MM-dd", null),
                    fechaCierre = "2024-06-24",
                    //fechaInicio = DateTime.ParseExact("2024-05-03", "yyyy-MM-dd", null),
                    fechaInicio = "2024-05-03",
                    idZcp = "75012",
                    municipio = "DIBULLA",
                    numeroTicketCcc = "192067",
                    numeroTicketProveedor = "202405032000034",
                    paradaReloj = "No",
                    region = "Norte A",
                    resumenCierre = "Buenos días, Se Realizó la Validación por parte de Interconexion en los Sistemas de información donde nos da como resultado: INSTITUCION ETNOEDUCATIVA INTERNADO RURAL DUMINGUEKA - SEDE PRINCIPAL - HUGHES : PARÁMETROS CORRECTOS - MERAKI AP : EN FUNCIONAMIENTO - RASPBERRY SENSORES CUMPLEN LOS PARÁMETROS CORRECTOS - PRTG: SENSORES EN FUNCIONAMIENTO Se anexa evidencias de la Funcionalidad del servicio También logramos evidenciar equipos en navegación y el SpeedTest.",
                    subcategoria = "intermitencia"
                },
                new Ticket()
                {
                    departamento = "CAUCA",
                    ejecutor = "UT ZCP 2023",
                    estado = "Asignado Operador",
                    //fechaCierre = DateTime.ParseExact("2026-02-09", "yyyy-MM-dd", null),
                    fechaCierre = "2026-02-09",
                    //fechaInicio = DateTime.ParseExact(null, "yyyy-MM-dd", null),
                    fechaInicio = null,
                    idZcp = "28609",
                    municipio = "EL TAMBO",
                    numeroTicketCcc = "R-018465",
                    numeroTicketProveedor = null,
                    paradaReloj = "No",
                    region = "SUR B",
                    resumenCierre = null,
                    subcategoria = "C4.5 Mantenimiento Preventivo o Correctivo"
                });

                context.SaveChanges();
            }
        }

        public static async Task seedRoles(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));

                if (!await roleManager.RoleExistsAsync(UserRoles.User))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));
            }
        }
    }
}
