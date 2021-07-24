using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using br21.core.entidade.jogo;


namespace SProfTIAPI.Services
{

    public class jogoService
    {

        private static dbmongo.MongoDatabase<entJogo> cr = new dbmongo.MongoDatabase<entJogo>(typeof(entJogo).FullName);

        public static List<entJogo> Get(out int errcode, int temporada, string NomeTime = "")
        {

            List<entJogo> result = new List<entJogo>();
            errcode = 500;
            try
            {

                Expression<Func<entJogo, bool>> Filtro = a => a.idttemporada.Equals(temporada) && 
                                                             (a.dsctimemandante.Contains(NomeTime) || a.dsctimevisitante.Contains(NomeTime));
                List<entJogo> Lcrt = cr.GetList(Filtro);


                errcode = 400;// <response code="400">valor do parametro inválido</response>
                foreach (var item in Lcrt)
                {
                    result.Add(
                            new entJogo()
                            {
                                idjogo = item.idjogo,
                                idttemporada = item.idttemporada,
                                rodada = item.rodada,
                                dtajogo = item.dtajogo,
                                idttimemandante = item.idttimemandante,
                                dsctimemandante = item.dsctimemandante,
                                vlrplacarmandante = item.vlrplacarmandante,
                                idttimevitante = item.idttimevitante,
                                dsctimevisitante = item.dsctimevisitante,
                                vlrplacarvisitante = item.vlrplacarvisitante
                            });
                }

                errcode = 200; // <response code="200">resultados da consulta</response>

            }
            catch (System.Exception ex)
            {

            }


            return result;

        }

        public static entJogo GetById(out int errcode, int? idtJogo)
        {

            entJogo result = null;
            errcode = 500;
            try
            {

                Expression<Func<entJogo, bool>> Filtro = a => a.idjogo == idtJogo;
                entJogo item = cr.GetOne(Filtro);

                if (item != null)
                {
                    errcode = 400;// <response code="400">valor do parametro inválido</response>
                    result = new entJogo()
                    {
                        idjogo = item.idjogo,
                        idttemporada = item.idttemporada,
                        rodada = item.rodada,
                        dtajogo = item.dtajogo,
                        idttimemandante = item.idttimemandante,
                        dsctimemandante = item.dsctimemandante,
                        vlrplacarmandante = item.vlrplacarmandante,
                        idttimevitante = item.idttimevitante,
                        dsctimevisitante = item.dsctimevisitante,
                        vlrplacarvisitante = item.vlrplacarvisitante
                    };
                }


                errcode = 200; // <response code="200">resultados da consulta</response>

            }
            catch (System.Exception ex)
            {

            }


            return result;

        }

        public static int Add(entJogo item)
        {

            int result = 201;// 201 - arteira incluida com sucesso

            try
            {

                result = 401;//401 - parametro ou estrutura de entrada inálida

                entJogo obj = new entJogo()
                {
                    idjogo = item.idjogo,
                    idttemporada = item.idttemporada,
                    rodada = item.rodada,
                    dtajogo = item.dtajogo,
                    idttimemandante = item.idttimemandante,
                    dsctimemandante = item.dsctimemandante,
                    vlrplacarmandante = item.vlrplacarmandante,
                    idttimevitante = item.idttimevitante,
                    dsctimevisitante = item.dsctimevisitante,
                    vlrplacarvisitante = item.vlrplacarvisitante
                };


                Expression<Func<entJogo, bool>> Filtro = a => a.idjogo == obj.idjogo ||
                                                            (a.idttimemandante == obj.idttimemandante && 
                                                            a.idttimevitante == obj.idttimevitante);
                entJogo crt = cr.GetOne(Filtro);


                if (crt != null)
                {
                    result = 409; //carteira já existente (Titulo ou id da carteira ja existe)
                    throw new Exception("409 - carteira já existente (Titulo ou id da carteira ja existe)");
                }


                cr.InsertOne(obj);
                result = 201;// 201 - arteira incluida com sucesso

            }
            catch (System.Exception ex)
            {


            }


            return result;

            // <response code="201">carteira incluida</response>
            // <response code="400">parametro ou estrutura de entrada inálida</response>
            // <response code="409">carteira já existente (nome da carteira ja existe)</response>
        }

        public static void Del(out int errcode, int? idjogo)
        {

            errcode = 400;// <response code="400">id da carteira inálida</response>
            try
            {

                Expression<Func<entJogo, bool>> Filtro = a => a.idjogo == idjogo;
                entJogo crt = cr.GetOne(Filtro);
                if (crt == null)
                {
                    errcode = 404; //404 - arteira nao encontrada
                    throw new Exception("404 - arteira nao encontrada");
                }

                // <response code="400">id da carteira inálida</response>

                cr.DeleteOne(Filtro);
                errcode = 202;// <response code="202">carteira excluída</response>

            }
            catch (System.Exception ex)
            {

            }

        }

        public static int Update(long? IDJogo, entJogo item)
        {

            int result = 201;// 201 - arteira incluida com sucesso

            try
            {

                result = 401;//401 - parametro ou estrutura de entrada inválida

                entJogo obj = new entJogo()
                {
                    idjogo = (long)IDJogo,
                    idttemporada = item.idttemporada,
                    rodada = item.rodada,
                    dtajogo = item.dtajogo,
                    idttimemandante = item.idttimemandante,
                    dsctimemandante = item.dsctimemandante,
                    vlrplacarmandante = item.vlrplacarmandante,
                    idttimevitante = item.idttimevitante,
                    dsctimevisitante = item.dsctimevisitante,
                    vlrplacarvisitante = item.vlrplacarvisitante
                };


                Expression<Func<entJogo, bool>> Filtro = a => a.idjogo == obj.idjogo;
                entJogo crt = cr.GetOne(Filtro);


                if (crt == null)
                {
                    result = 404; //404 - carteira nao encontrada
                    throw new Exception("409 - carteira já existente (Titulo ou id da carteira ja existe)");
                }


                var update = MongoDB.Driver.Builders<entJogo>.Update;
                var updates = new List<MongoDB.Driver.UpdateDefinition<entJogo>>();


                updates.Add(update.Set("idjogo", obj.idjogo));
                updates.Add(update.Set("idttemporada", obj.idttemporada));
                updates.Add(update.Set("rodada", obj.rodada));
                updates.Add(update.Set("dtajogo", obj.dtajogo));
                updates.Add(update.Set("idttimemandante", obj.idttimemandante));
                updates.Add(update.Set("dsctimemandante", obj.dsctimemandante));
                updates.Add(update.Set("vlrplacarmandante", obj.vlrplacarmandante));
                updates.Add(update.Set("idttimevitante", obj.idttimevitante));
                updates.Add(update.Set("dsctimevisitante", obj.dsctimevisitante));
                updates.Add(update.Set("vlrplacarvisitante", obj.vlrplacarvisitante));



                cr.UpdateOne(Filtro, update.Combine(updates));
                result = 201;// 201 - arteira incluida com sucesso


            }
            catch (System.Exception ex)
            {


            }


            return result;

            // <response code="201">carteira incluida</response>
            // <response code="400">Identificador da carteira fornecido é inválido</response>
            // <response code="401">401 - parametro ou estrutura de entrada inálida</response>
            // <response code="409">carteira já existente (nome da carteira ja existe)</response>
            // <response code="404">carteira nao encontrada</response>
            // <response code="405">Exceção na autalização dos dados da carteira</response>
        }



    }

}