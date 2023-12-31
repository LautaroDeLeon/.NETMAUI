﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavigationServiceMAUI.Services
{
    public class NavigationService : INavigationService
    {
        public IDictionary<string, object> parametersAux;
        public T GetPageViewModel<T>() where T : new()
        {
            var pageDetails = Shell.Current.CurrentItem.CurrentItem.Stack.Where(x => x!=null && x.BindingContext.GetType()==typeof(T)).FirstOrDefault();
            if(pageDetails != null)
            {
                return (T)pageDetails.BindingContext;
            }
            return default(T);
        }

        public IDictionary<string, object> GetParameters()
        {
            return parametersAux;
        }

        public Task NavigateToAsync(string route, IDictionary<string, object> parameters)
        {
            if (parameters != null)
            {
                parametersAux = parameters;
                return Shell.Current.GoToAsync(route, parameters);
            }
            else
            {
                return Shell.Current.GoToAsync(route);
            }
        }
    }
}
