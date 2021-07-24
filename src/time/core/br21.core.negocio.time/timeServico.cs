using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using br21.core.entidade.time;


namespace br21.core.negocio.time
{

    public class jogoService
    {

        private static dbmongo.MongoDatabase<entTime> cr = new dbmongo.MongoDatabase<entTime>(typeof(entTime).FullName);

        public static List<entTime> Get(out int errcode, string idtime="*")
        {

            List<entTime> result = new List<entTime>();
            errcode = 500;
            try
            {

                Expression<Func<entTime, bool>> Filtro = a => true;
                if (idtime!="*")
                    Filtro = a => a.idttime == idtime;  //(a.dsctime.Contains(NomeTime) || a.dsctime.Contains(NomeTime));
                List <entTime> Lcrt = cr.GetList(Filtro);

                errcode = 400;// <response code="400">valor do parametro inválido</response>
                foreach (var item in Lcrt)
                {
                    result.Add(
                            new entTime()
                            {
                                idttime = item.idttime,
                                sgltime = item.sgltime,
                                dsctime = item.dsctime,
                                //imgescudo = item.imgescudo
                            });
                }

                errcode = 200; // <response code="200">resultados da consulta</response>

            }
            catch (System.Exception ex)
            {

            }


            return result;

        }

        public static entTime GetById(out int errcode, string idtTime)
        {

            entTime result = null;
            errcode = 500;
            try
            {

                Expression<Func<entTime, bool>> Filtro = a => a.idttime == idtTime;
                entTime item = cr.GetOne(Filtro);

                if (item != null)
                {
                    errcode = 400;// <response code="400">valor do parametro inválido</response>
                    result = new entTime()
                    {
                        idttime = item.idttime,
                        sgltime = item.sgltime,
                        dsctime = item.dsctime,
                        //imgescudo = item.imgescudo
                    };
                }


                errcode = 200; // <response code="200">resultados da consulta</response>

            }
            catch (System.Exception ex)
            {

            }


            return result;

        }

        public static int Add(entTime item)
        {

            int result = 201;// 201 - arteira incluida com sucesso

            try
            {

                result = 401;//401 - parametro ou estrutura de entrada inálida

                entTime obj = new entTime()
                {
                    idttime = item.idttime,
                    sgltime = item.sgltime,
                    dsctime = item.dsctime,
                    //imgescudo = item.imgescudo
                };


                Expression<Func<entTime, bool>> Filtro = a => a.idttime == obj.idttime ||
                                                              a.dsctime == obj.dsctime ||
                                                              a.sgltime == obj.sgltime;

                entTime crt = cr.GetOne(Filtro);


                if (crt != null)
                {
                    result = 409; //carteira já existente (Titulo ou id da carteira ja existe)
                    throw new Exception("409 - Time já existente (id ou Nome(descrição) ou sigla do time ja existe)");
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

        public static void Del(out int errcode, string idtTime)
        {

            errcode = 400;// <response code="400">id da carteira inálida</response>
            try
            {

                Expression<Func<entTime, bool>> Filtro = a => a.idttime == idtTime;
                entTime crt = cr.GetOne(Filtro);
                if (crt == null)
                {
                    errcode = 404; //404 - arteira nao encontrada
                    throw new Exception("404 - Time nao encontrado");
                }

                // <response code="400">id da carteira inálida</response>

                cr.DeleteOne(Filtro);
                errcode = 202;// <response code="202">carteira excluída</response>

            }
            catch (System.Exception ex)
            {

            }

        }

        public static int Update(long? IDJogo, entTime item)
        {

            int result = 201;// 201 - arteira incluida com sucesso

            try
            {

                result = 401;//401 - parametro ou estrutura de entrada inválida

                entTime obj = new entTime()
                {
                    idttime = item.idttime,
                    sgltime = item.sgltime,
                    dsctime = item.dsctime,
                    //imgescudo = item.imgescudo

                };


                Expression<Func<entTime, bool>> Filtro = a => a.idttime == obj.idttime ||
                                                              a.dsctime == obj.dsctime ||
                                                              a.sgltime == obj.sgltime;
                entTime crt = cr.GetOne(Filtro);


                if (crt == null)
                {
                    result = 404; //404 - carteira nao encontrada
                    throw new Exception("409 - Time já existente (id ou Nome(descrição) ou sigla do time ja existe)");
                }


                var update = MongoDB.Driver.Builders<entTime>.Update;
                var updates = new List<MongoDB.Driver.UpdateDefinition<entTime>>();

                updates.Add(update.Set("idttime",obj.idttime));
                updates.Add(update.Set("sgltime", obj.sgltime));
                updates.Add(update.Set("dsctime", obj.dsctime));
                //updates.Add(update.Set("imgescudo", obj.imgescudo));

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