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
using Assets.Scripts.Model;
using Assets.src.RESTful_Server.models;
using Assets.Scripts;
using System.Linq;
using static UnityEngine.ParticleSystem;
using Assets.Scripts.Utils;

namespace RESTfulHTTPServer.src.invoker
{
	public class TrainInvoke : MonoBehaviour
    {
        private const string TAG = "Train Invoke";
        
		/// <summary>
        /// Sets the color of a game object.
        /// </summary>
        /// <returns>The color.</returns>
        /// <param name="request">Request.</param>
        public static Response Post(Request request)
		{
			Response response = new Response();
			string responseData = "";
			string json = request.GetPOSTData();
			var trainRequest = JsonUtility.FromJson<TrainRequest>(json);
            var valid = true;

			UnityInvoker.ExecuteOnMainThread.Enqueue (() => {

                var gameTrain = DataHelper.trains.Where(a => a.Id == trainRequest.id).FirstOrDefault();

                if (gameTrain != null)
				{
                    gameTrain.Color = trainRequest.color;
                    gameTrain.Speed = (float)trainRequest.speed;
					responseData = gameTrain.Id + ", " + gameTrain + ", " + gameTrain.Speed;
                    response.SetHTTPStatusCode((int)HttpStatusCode.OK);
                }
                else {

					// 404 - Object not found
					responseData = "404";
					response.SetContent(responseData);
					response.SetHTTPStatusCode((int) HttpStatusCode.NotFound);
					response.SetMimeType(Response.MIME_CONTENT_TYPE_HTML);
				}
			});

			// Wait for the main thread
			while (responseData.Equals("")) {}

			// Filling up the response with data
			if (valid) {

				// 200 - OK
				response.SetContent(responseData);
				response.SetHTTPStatusCode ((int)HttpStatusCode.OK);
				response.SetMimeType (Response.MIME_CONTENT_TYPE_JSON);
			} else {

				// 406 - Not acceptable
				response.SetContent("Failed to deseiralised JSON");
				response.SetHTTPStatusCode((int) HttpStatusCode.NotAcceptable);
				response.SetMimeType(Response.MIME_CONTENT_TYPE_HTML);
			}

			return response;
		}
	}
}

