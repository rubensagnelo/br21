using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using br21.core.entidade.jogo;
using proxy;


namespace br21.core.negocio.jogo
{

    public class jogoServico
    {

        private static dbmongo.MongoDatabase<entJogo> cr = new dbmongo.MongoDatabase<entJogo>(typeof(entJogo).FullName);

        public static entJogosRetorno Get(out int errcode, string urlServiceTime, int temporada=0, int rodada=0, long idJogo = 0)
        {

            entJogosRetorno result = new entJogosRetorno();
            errcode = 500;
            try
            {
                Expression<Func<entJogo, bool>> Filtro = a => true;

                if (temporada > 0)
                {
                    Filtro = a => a.idttemporada.Equals(temporada);

                    if (rodada > 0)
                    {
                        Filtro = a => (a.idttemporada.Equals(temporada) && a.rodada.Equals(rodada));
                    }
                }

                if (idJogo > 0)
                    Filtro = a => a.idjogo.Equals(idJogo);


                List<entJogo> Lcrt = cr.GetList(Filtro);

                Ext_entTimes times = null;
                try
                {
                    times = WebAPIProxy.Get<Ext_entTimes>(urlServiceTime);
                }
                catch (Exception) { }
                
                string timemandante = null;
                string timevisitante = null;
                Ext_entTime resultprxTime = null;

                errcode = 400;// <response code="400">valor do parametro inválido</response>
                foreach (var item in Lcrt)
                {
                    timemandante = string.Empty;
                    try
                    {
                        resultprxTime = times.Where(p => p.idttime.Equals(item.idttimemandante)).First();
                        if (resultprxTime != null) timemandante = resultprxTime.dsctime;
                    }
                    catch {}

                    timevisitante = string.Empty;
                    try
                    {
                        resultprxTime = times.Where(p => p.idttime.Equals(item.idttimevisitante)).First();
                        if (resultprxTime != null) timevisitante = resultprxTime.dsctime;
                    }
                    catch {}


                    result.Add(
                            new entJogoRetorno()
                            {
                                idjogo = item.idjogo,
                                idttemporada = item.idttemporada,
                                rodada = item.rodada,
                                dtajogo = item.dtajogo,
                                idttimemandante = item.idttimemandante,
                                dsctimemandante = timemandante,//Retorno do serviço esxterno (Time)
                                vlrplacarmandante = item.vlrplacarmandante,
                                idttimevisitante = item.idttimevisitante,
                                dsctimevisitante = timevisitante,
                                vlrplacarvisitante = item.vlrplacarvisitante
                            });
                }

                errcode = 200; // <response code="200">resultados da consulta</response>

            }
            catch (System.Exception ex)
            {
                throw ex;
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
                        //dsctimemandante = item.dsctimemandante,
                        vlrplacarmandante = item.vlrplacarmandante,
                        idttimevisitante = item.idttimevisitante,
                        //dsctimevisitante = item.dsctimevisitante,
                        vlrplacarvisitante = item.vlrplacarvisitante
                    };
                }


                errcode = 200; // <response code="200">resultados da consulta</response>

            }
            catch (System.Exception)
            {

            }


            return result;

        }

        public static int Add(entJogo item)
        {

            int result = 201;// 201 - jogo incluida com sucesso

            try
            {

                result = 400;//400 - parametro ou estrutura de entrada inálida

                entJogo obj = new entJogo()
                {
                    _id = Guid.NewGuid().ToString(),
                    idjogo = item.idjogo,
                    idttemporada = item.idttemporada,
                    rodada = item.rodada,
                    dtajogo = item.dtajogo,
                    idttimemandante = item.idttimemandante,
                    vlrplacarmandante = item.vlrplacarmandante,
                    idttimevisitante = item.idttimevisitante,
                    vlrplacarvisitante = item.vlrplacarvisitante
                };


                Expression<Func<entJogo, bool>> Filtro = a => a.idjogo == obj.idjogo ||
                                                            (   a.idttemporada == obj.idttemporada &&
                                                                a.rodada == obj.rodada &&
                                                                a.idttimemandante == obj.idttimemandante && 
                                                                a.idttimevisitante == obj.idttimevisitante
                                                              );
                entJogo crt = cr.GetOne(Filtro);


                if (crt != null)
                {
                    result = 409; //jogo já existente (Titulo ou id da carteira ja existe)
                    throw new Exception("409 - carteira já existente (Titulo ou id da carteira ja existe)");
                }


                cr.InsertOne(obj);
                result = 201;// 201 - jogo incluido com sucesso

            }
            catch (System.Exception)
            {


            }


            return result;

            // <response code="201">jogo incluido com sucesso</response>
            // <response code="400">parametro ou estrutura de entrada inálida</response>
            // <response code="409">jogo já existente (nome da carteira ja existe)</response>
        }

        public static void Del(out int errcode, int? idjogo)
        {

            errcode = 400;// <response code="400">id da jogo inálido</response>
            try
            {

                Expression<Func<entJogo, bool>> Filtro = a => a.idjogo == idjogo;
                entJogo crt = cr.GetOne(Filtro);
                if (crt == null)
                {
                    errcode = 404; //404 - jogo nao encontrada
                    throw new Exception("404 - arteira nao encontrada");
                }

                // <response code="400">id do jogo inálido</response>

                cr.DeleteOne(Filtro);
                errcode = 202;// <response code="202">jogo excluído</response>

            }
            catch (System.Exception)
            {

            }

        }

        public static int Update(long? IDJogo, entJogo item)
        {

            int result = 202;// 202 - Jogo atualizado com sucesso

            try
            {

                result = 400;//400 - parametro ou estrutura de entrada inálida

                entJogo obj = new entJogo()
                {
                    idjogo = (long)IDJogo,
                    idttemporada = item.idttemporada,
                    rodada = item.rodada,
                    dtajogo = item.dtajogo,
                    idttimemandante = item.idttimemandante,
                    //dsctimemandante = item.dsctimemandante,
                    vlrplacarmandante = item.vlrplacarmandante,
                    idttimevisitante = item.idttimevisitante,
                    //dsctimevisitante = item.dsctimevisitante,
                    vlrplacarvisitante = item.vlrplacarvisitante
                };


                Expression<Func<entJogo, bool>> Filtro = a => a.idjogo == IDJogo;
                entJogo crt = cr.GetOne(Filtro);


                if (crt == null)
                {
                    result = 404; //404 - jogo nao encontrado
                    throw new Exception("404 - jogo não encontrado");
                }


                var update = MongoDB.Driver.Builders<entJogo>.Update;
                var updates = new List<MongoDB.Driver.UpdateDefinition<entJogo>>();


                updates.Add(update.Set("idjogo", obj.idjogo));
                updates.Add(update.Set("idttemporada", obj.idttemporada));
                updates.Add(update.Set("rodada", obj.rodada));
                updates.Add(update.Set("dtajogo", obj.dtajogo));
                updates.Add(update.Set("idttimemandante", obj.idttimemandante));
                //updates.Add(update.Set("dsctimemandante", obj.dsctimemandante));
                updates.Add(update.Set("vlrplacarmandante", obj.vlrplacarmandante));
                updates.Add(update.Set("idttimevisitante", obj.idttimevisitante));
                //updates.Add(update.Set("dsctimevisitante", obj.dsctimevisitante));
                updates.Add(update.Set("vlrplacarvisitante", obj.vlrplacarvisitante));



                cr.UpdateOne(Filtro, update.Combine(updates));
                result = 202;// 202 - jogo atualizado com sucesso


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