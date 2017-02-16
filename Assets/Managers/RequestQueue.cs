﻿using System;
using System.Collections;

namespace PubNubAPI
{
    public sealed class RequestQueue
    {        
        private RequestQueue ()
        {
        }
        private PNConfiguration PNConfig { get; set;}
        private static volatile RequestQueue instance;
        private static object syncRoot = new System.Object();
        //SafeDictionary<PNOperationType, object> queuedRequests = new SafeDictionary<PNOperationType, object> ();
        private Queue q = new Queue();

        public int QueueCount {
            get;
            private set;
        }

        public bool HasItems {get; private set;}

        public static RequestQueue Instance
        {
            get 
            {
                if (instance == null) 
                {
                    lock (syncRoot) 
                    {
                        if (instance == null) 
                            instance = new RequestQueue();
                    }
                }

                return instance;
            }
        }

        public void Enqueue<T>(PNConfiguration pnConfig, Action<T, PNStatus> callback, PNOperationType operationType, OperationParams operationParams){
            //queuedRequests.AddOrUpdate (operationType, callback, (oldData, newData) => callback);
            this.PNConfig = pnConfig;
            QueueStorage qs = new QueueStorage(callback, operationType, operationParams);
            q.Enqueue(qs);
            Reset ();
        }

        internal QueueStorage Dequeue(){
            object o = q.Dequeue ();
            QueueStorage qs = o as QueueStorage;
            Reset ();
            return qs;//queuedRequests[operationType];
        }

        public void Reset(){
            if (q.Count > 0) {
                HasItems = true;
            } else {
                HasItems = false;
            }
        }
    }
}

