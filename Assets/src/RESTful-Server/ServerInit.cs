﻿using UnityEngine;
using System.Collections;
using RESTfulHTTPServer;
using RESTfulHTTPServer.src.controller;
using RESTfulHTTPServer.src.models;
using Assets.Scripts.Utils;

public class ServerInit : MonoBehaviour
{
    private const string TAG = "Server Init";

    public int port = 8080;
    public string username = "";
    public string password = "";

	/// <summary>
	/// Use this for initialization
	/// </summary>
	void Awake () {

		// Make sure the applications continues to run in the background
		Application.runInBackground = true;
        DataHelper.InitializeData();
		// ------------------------------
		// Creating a Simple REST server
		// ------------------------------

		// 1. Create the routing table
		// HTTP Type 	 - URL routing path with variables 	- Class and method to be called
		// HTTP Type     - /foo/bar/{variable}   			- DelegetorClass.MethodToBeCalled
		RoutingManager routingManager = new RoutingManager();
		routingManager.AddRoute(new Route(Route.Type.GET, "/color/{objname}", "MaterialInvoke.GetColor"));
		routingManager.AddRoute(new Route(Route.Type.POST, "/color/{objname}", "MaterialInvoke.SetColor"));
		routingManager.AddRoute(new Route(Route.Type.DELETE, "/color/{objname}", "MaterialInvoke.DeleteColor"));

        // POPRAWNE API - NIE ZMIENIAĆ MI TRAIN-INVOKE
        routingManager.AddRoute(new Route(Route.Type.GET, "/train/{id}", "TrainInvoke.Get"));
        routingManager.AddRoute(new Route(Route.Type.PUT, "/train/{id}", "TrainInvoke.Put"));
        routingManager.AddRoute(new Route(Route.Type.POST, "/train/{id}", "TrainInvoke.Post"));
        routingManager.AddRoute(new Route(Route.Type.DELETE, "/train/{id}", "TrainInvoke.Delete"));


        // Starts the Simple REST Server
        // With or without basic authorisation flag
        if (!username.Equals("") && !password.Equals(""))
        {
            RESTfulHTTPServer.src.controller.Logger.Log(TAG, "Create basic auth");
            BasicAuth basicAuth = new BasicAuth(username, password);
            new SimpleRESTServer(port, routingManager, basicAuth);
        }
        else
        {
            new SimpleRESTServer(port, routingManager);
        }
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update() { }
}
