using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Expressions;
using Segundoparcial._2.Data;
using Segundoparcial._2.Models;

using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Segundoparcial._2.Controllers
{
    public class TelefonosControllers
    {
        public static bool Guardar(Telefonos entity)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                if (!contexto.telefonos.Any(A => A.LlamadaId == entity.LlamadaId) && entity.LlamadaId == 0)
                {
                    paso = Insertar(entity);
                }
                else
                {
                    if (contexto.telefonos.Any(A => A.LlamadaId == entity.LlamadaId))
                        paso = Modificar(entity);
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return paso;
        }

        private static bool Insertar(Telefonos entity)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                contexto.telefonos.Add(entity);
                paso = contexto.SaveChanges() > 0;

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return paso;
        }

        private static bool Modificar(Telefonos entity)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                var anterior = Buscar(entity.LlamadaId);

                foreach (var obj in entity.Detalles)
                {
                    if (obj.CasoId == 0)
                    {
                        contexto.Entry(obj).State = EntityState.Added;
                    }
                }

                foreach (var obj in anterior.Detalles)
                {
                    if (!entity.Detalles.Any(A=> A.CasoId == obj.CasoId))
                    {
                        contexto.Entry(obj).State = EntityState.Deleted;
                    }
                }

//              

                contexto.Entry(entity).State = EntityState.Modified;
                paso =  contexto.SaveChanges() > 0;

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return paso;
        }

        public static bool Eliminar(int Id)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                Telefonos llamada = Buscar(Id);
                if (llamada != null)
                {
                    db.Entry(llamada).State = EntityState.Deleted;
                    paso = db.SaveChanges() > 0;
                }

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                db.Dispose();
            }

            return paso;
        }

        public static Telefonos Buscar(int Id)
        {
            Contexto db = new Contexto();
            Telefonos llamada = null;
            try
            {
                llamada = db.telefonos.Where(A => A.LlamadaId == Id).Include(A => A.Detalles).FirstOrDefault();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                db.Dispose();
            }

            return llamada;
        }


        public static List<Telefonos> GetList(Expression<Func<Telefonos, bool>> expresion)
        {
            List<Telefonos> lista = new List<Telefonos>();
            Contexto db = new Contexto();

            try
            {
                lista = db.telefonos.Where(expresion).Include(A => A.Detalles).ToList();
            }
            catch (Exception)
            {

                throw;
            }

            return lista;
        }
    }
}
