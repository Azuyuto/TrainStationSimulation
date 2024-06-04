// RESTful-Unity
// Copyright (C) 2016 - Tim F. Rieck
//
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
//	You should have received a copy of the GNU General Public License
//	along with this program. If not, see <http://www.gnu.org/licenses/>.
//
// <copyright file="ServerInit.cs" company="TRi">
// Copyright (c) 2016 All Rights Reserved
// </copyright>
// <author>Tim F. Rieck</author>
// <date>29/11/2016 10:13 AM</date>

using UnityEngine;
using System;
using System.Net;
using RESTfulHTTPServer.src.models;
using RESTfulHTTPServer.src.controller;
using Assets.Scripts.Utils;
using System.Linq;
using Assets.src.RESTful_Server.models;
using Newtonsoft.Json;
using System.Collections.Generic;
using Assets.Scripts.Model;

namespace RESTfulHTTPServer.src.invoker
{
    public class TrainInvoke
    {
        private const string TAG = "Train Invoke";

        public static Response Get(Request request)
        {
            Response response = new Response();
            string id = request.GetParameter("id");
            string responseData = "";

            // Verbose all URL variables
            foreach (string key in request.GetQuerys().Keys)
            {

                string value = request.GetQuery(key);
                RESTfulHTTPServer.src.controller.Logger.Log(TAG, "key: " + key + " , value: " + value);
            }

            UnityInvoker.ExecuteOnMainThread.Enqueue(() => {

                // Determine our object in the scene
                var gameTrain = DataHelper.Trains.Where(a => a.Id == id).FirstOrDefault();
                if (gameTrain != null)
                {
                    try
                    {
                        responseData = JsonConvert.SerializeObject(gameTrain, new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
                        response.SetContent(responseData);
                        response.SetHTTPStatusCode((int)HttpStatusCode.OK);
                    }
                    catch (Exception e)
                    {
                        string msg = "Failed to seiralised JSON";
                        responseData = msg;

                        RESTfulHTTPServer.src.controller.Logger.Log(TAG, msg);
                        RESTfulHTTPServer.src.controller.Logger.Log(TAG, e.ToString());
                    }

                }
                else
                {
                    // 404 - Object not found
                    responseData = JsonConvert.SerializeObject(new { message = "Not found train with id: " + id });
                    response.SetContent(responseData);
                    response.SetHTTPStatusCode((int)HttpStatusCode.NotFound);
                    response.SetMimeType(Response.MIME_CONTENT_TYPE_HTML);
                }
            });

            // Wait for the main thread
            while (responseData.Equals("")) { }

            // 200 - OK
            // Fillig up the response with data
            response.SetContent(responseData);
            response.SetMimeType(Response.MIME_CONTENT_TYPE_JSON);

            return response;
        }

        public static Response Put(Request request)
        {
            Response response = new Response();
            string id = request.GetParameter("id");
            string responseData = "";
            string json = request.GetPOSTData();
            var trainRequest = JsonConvert.DeserializeObject<Train>(json);
            var valid = true;

            UnityInvoker.ExecuteOnMainThread.Enqueue(() => {
                if (id != trainRequest.Id)
                {
                    // 406 - Ids not compare.
                    responseData = JsonConvert.SerializeObject(new { message = "Id from parameter " + id + " is not equal to id from request body " + trainRequest.Id + "." });
                    response.SetContent(responseData);
                    response.SetHTTPStatusCode((int)HttpStatusCode.NotFound);
                    response.SetMimeType(Response.MIME_CONTENT_TYPE_HTML);
                    return;
                }

                var gameTrain = new Train()
                {
                    Id = trainRequest.Id,
                    Color = trainRequest.Color,
                    ToDelete = false,
                    ArrivedLength = trainRequest.ArrivedLength,
                    Speed = trainRequest.Speed,
                    ParentTrack = trainRequest.ParentTrack,
                    ToAdd = true
                };
                DataHelper.Trains.Add(gameTrain);
                DataHelper.AttachModels();

                responseData = JsonConvert.SerializeObject(gameTrain, new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
                response.SetContent(responseData);
                response.SetHTTPStatusCode((int)HttpStatusCode.OK);
            });

            // Wait for the main thread
            while (responseData.Equals("")) { }

            // Filling up the response with data
            if (valid)
            {

                // 200 - OK
                response.SetContent(responseData);
                response.SetHTTPStatusCode((int)HttpStatusCode.OK);
                response.SetMimeType(Response.MIME_CONTENT_TYPE_JSON);
            }
            else
            {

                // 406 - Not acceptable
                response.SetContent("Failed to deseiralised JSON");
                response.SetHTTPStatusCode((int)HttpStatusCode.NotAcceptable);
                response.SetMimeType(Response.MIME_CONTENT_TYPE_HTML);
            }

            return response;
        }

        public static Response Post(Request request)
        {
            Response response = new Response();
            string id = request.GetParameter("id");
            string responseData = "";
            string json = request.GetPOSTData();
            var trainRequest = JsonConvert.DeserializeObject<Train>(json);
            var valid = true;

            UnityInvoker.ExecuteOnMainThread.Enqueue(() => {
                if(id != trainRequest.Id)
                {
                    // 406 - Ids not compare.
                    responseData = JsonConvert.SerializeObject(new { message = "Id from parameter " + id + " is not equal to id from request body " + trainRequest.Id + "." });
                    response.SetContent(responseData);
                    response.SetHTTPStatusCode((int)HttpStatusCode.NotFound);
                    response.SetMimeType(Response.MIME_CONTENT_TYPE_HTML);
                    return;
                }

                var gameTrain = DataHelper.Trains.Where(a => a.Id == trainRequest.Id).FirstOrDefault();

                if (gameTrain != null)
                {
                    gameTrain.Color = trainRequest.Color;
                    gameTrain.Speed = trainRequest.Speed;
                    gameTrain.ArrivedLength = trainRequest.ArrivedLength;
                    responseData = JsonConvert.SerializeObject(gameTrain, new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
                    response.SetContent(responseData);
                    response.SetHTTPStatusCode((int)HttpStatusCode.OK);
                }
                else
                {
                    // 404 - Object not found
                    responseData = JsonConvert.SerializeObject(new { message = "Not found train with id: " + trainRequest.Id });
                    response.SetContent(responseData);
                    response.SetHTTPStatusCode((int)HttpStatusCode.NotFound);
                    response.SetMimeType(Response.MIME_CONTENT_TYPE_HTML);
                }
            });

            // Wait for the main thread
            while (responseData.Equals("")) { }

            // Filling up the response with data
            if (valid)
            {

                // 200 - OK
                response.SetContent(responseData);
                response.SetHTTPStatusCode((int)HttpStatusCode.OK);
                response.SetMimeType(Response.MIME_CONTENT_TYPE_JSON);
            }
            else
            {

                // 406 - Not acceptable
                response.SetContent("Failed to deseiralised JSON");
                response.SetHTTPStatusCode((int)HttpStatusCode.NotAcceptable);
                response.SetMimeType(Response.MIME_CONTENT_TYPE_HTML);
            }

            return response;
        }

        public static Response Delete(Request request)
        {
            Response response = new Response();
            string responseData = "";
            string id = request.GetParameter("id");

            UnityInvoker.ExecuteOnMainThread.Enqueue(() => {

                // Determine our object in the scene
                var gameTrain = DataHelper.Trains.Where(a => a.Id == id).FirstOrDefault();
                if (gameTrain != null)
                {
                    gameTrain.ToDelete = true;
                    responseData = JsonConvert.SerializeObject(new { message = "Successfully removed: " + id });
                    response.SetContent(responseData);
                    response.SetHTTPStatusCode((int)HttpStatusCode.OK);
                }
                else
                {
                    // 404 - Not Found
                    responseData = JsonConvert.SerializeObject(new { message = "Not found train with id: " + id });
                    response.SetContent(responseData);
                    response.SetHTTPStatusCode((int)HttpStatusCode.NotFound);
                    response.SetMimeType(Response.MIME_CONTENT_TYPE_HTML);
                }
            });

            // Wait for the main thread
            while (responseData.Equals("")) { }

            response.SetContent(responseData);
            response.SetMimeType(Response.MIME_CONTENT_TYPE_JSON);
            return response;
        }
    }
}

