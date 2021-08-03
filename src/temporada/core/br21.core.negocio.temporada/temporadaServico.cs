using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using br21.core.entidade.temporada;

namespace br21.core.negocio.temporada
{
    public class temporadaServico
    {

        private static dbmongo.MongoDatabase<entTemporada> cr = new dbmongo.MongoDatabase<entTemporada>(typeof(entTemporada).FullName);

        public static List<entTemporada> Get(out int errcode, int idTemporada=0)
        {

            List<entTemporada> result = new List<entTemporada>();
            errcode = 500;
            try
            {

                Expression<Func<entTemporada, bool>> Filtro = a => true;
                if (idTemporada > 0)
                    Filtro = a => a.idtemporada == idTemporada;  //(a.dsctime.Contains(NomeTime) || a.dsctime.Contains(NomeTime));
                List<entTemporada> Lcrt = cr.GetList(Filtro);

                errcode = 400;// <response code="400">valor do parametro inválido</response>
                foreach (var item in Lcrt)
                {
                    result.Add(
                            new entTemporada()
                            {
                                idtemporada = item.idtemporada
                            });
                }

                errcode = 200; // <response code="200">resultados da consulta</response>

            }
            catch (System.Exception)
            {

            }


            return result;

        }

        public static entTemporada GetById(out int errcode, int idtemporada)
        {

            entTemporada result = null;
            errcode = 500;
            try
            {

                Expression<Func<entTemporada, bool>> Filtro = a => a.idtemporada == idtemporada;
                entTemporada item = cr.GetOne(Filtro);

                if (item != null)
                {
                    errcode = 400;// <response code="400">valor do parametro inválido</response>
                    result = new entTemporada()
                    {
                        idtemporada = item.idtemporada
                    };
                }


                errcode = 200; // <response code="200">resultados da consulta</response>

            }
            catch (System.Exception)
            {

            }


            return result;

        }

        public static int Add(entTemporada item)
        {

            int result = 201;// 201 - arteira incluida com sucesso

            try
            {

                result = 400;//400 - parametro ou estrutura de entrada inálida

                entTemporada obj = new entTemporada()
                {
                    idtemporada = item.idtemporada
                };


                Expression<Func<entTemporada, bool>> Filtro = a => a.idtemporada == obj.idtemporada;

                entTemporada crt = cr.GetOne(Filtro);


                if (crt != null)
                {
                    result = 409; //Temporada já existente.
                    throw new Exception("409 - emporada já existente");
                }


                cr.InsertOne(obj);
                result = 201;// 201 - arteira incluida com sucesso

            }
            catch (System.Exception)
            {


            }


            return result;

            // <response code="201">carteira incluida</response>
            // <response code="400">parametro ou estrutura de entrada inálida</response>
            // <response code="409">carteira já existente (nome da carteira ja existe)</response>
        }

        public static void Del(out int errcode, int idtemporada)
        {

            errcode = 400;// <response code="400">id da carteira inálida</response>
            try
            {

                Expression<Func<entTemporada, bool>> Filtro = a => a.idtemporada == idtemporada;
                entTemporada crt = cr.GetOne(Filtro);
                if (crt == null)
                {
                    errcode = 404; //404 - Temporada nao encontrada
                    throw new Exception("404 - Temporada nao encontrada");
                }

                // <response code="400">id da carteira inálida</response>

                cr.DeleteOne(Filtro);
                errcode = 202;// <response code="202">carteira excluída</response>

            }
            catch (System.Exception)
            {

            }

        }

        public static int Update(long? IDTemporada, entTemporada item)
        {

            int result = 204;// 204 - Temporada atualizada com sucesso

            try
            {

                result = 400;//400 - parametro ou estrutura de entrada inálida

                entTemporada obj = new entTemporada()
                {
                    idtemporada = item.idtemporada
                };


                Expression<Func<entTemporada, bool>> Filtro = a => a.idtemporada == IDTemporada;
                entTemporada crt = cr.GetOne(Filtro);


                if (crt == null)
                {
                    result = 404; //404 - Temporada não encontrada
                    throw new Exception("409 - Temporada ja existente)");
                }


                var update = MongoDB.Driver.Builders<entTemporada>.Update;
                var updates = new List<MongoDB.Driver.UpdateDefinition<entTemporada>>();

                updates.Add(update.Set("idtemporada", obj.idtemporada));
                //updates.Add(update.Set("imgescudo", obj.imgescudo));

                cr.UpdateOne(Filtro, update.Combine(updates));
                result = 204;// 204 - temporada alterada com sucesso


            }
            catch (System.Exception)
            {


            }


            return result;

            // <response code="201">carteira incluida</response>
            // <response code="400">Identificador da carteira fornecido é inválido</response>
            // <response code="400">400 - parametro ou estrutura de entrada inálida</response>
            // <response code="409">carteira já existente (nome da carteira ja existe)</response>
            // <response code="404">carteira nao encontrada</response>
            // <response code="405">Exceção na autalização dos dados da carteira</response>
        }


    }
}
