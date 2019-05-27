

using CommonServiceLocator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using MailSenderLib.Linq2SQL;
using MailSenderLib.Services;
using MailSenderLib.Services.InMemory;
using MailSenderLib.Services.Interfaces;
using System;
//using Microsoft.Practices.ServiceLocation;

namespace Lesson1.ViewModel
{
    public class ViewModelLocator
    {        
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            SimpleIoc.Default.TryRegister(() => new MailSenderDB());



            SimpleIoc.Default
                .TryRegister<IRecepientsData, RecipientsDataInMemory>()
                .TryRegister<IMailLists, MailsListDataInMemory>()
                .TryRegister<IMailMessagesData, MailMessageDataInMemory>()
                .TryRegister<IServerData, ServersDataInMemory>()
                .TryRegister<IRecipientsListData, RecipientsListDataInMemory>()
                .TryRegister<ISendersData, SendersDataInMemory>()
                .TryRegister<ISchedulerTasksData, SchedulerTasksDataInMemory>();
            
            SimpleIoc.Default.TryRegister<MainWindowViewModel>();
        }
                
        public MainWindowViewModel MainWindowModel => ServiceLocator.Current.GetInstance<MainWindowViewModel>();
        
        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }

    internal static class SimpleIocExtensions
    {
        public static SimpleIoc TryRegister<T>(this SimpleIoc container, Func<T> factory) where T : class
        {
            if (container.IsRegistered<T>()) return container;

            container.Register(factory);
            return container;
        }

        public static SimpleIoc TryRegister<T>(this SimpleIoc container) where T : class
        {
            if (container.IsRegistered<T>()) return container;

            container.Register<T>();
            return container;
        }

        public static SimpleIoc TryRegister<TInterface, TClass>(this SimpleIoc container) 
            where TInterface : class
            where TClass : class, TInterface
        {
            if (container.IsRegistered<TInterface>()) return container;

            container.Register<TInterface, TClass>();
            return container;
        }
    }
}