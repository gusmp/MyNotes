/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:MyNotes"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Messaging;
using Microsoft.Practices.ServiceLocation;
using MyNotes.Repository;
using MyNotes.Repository.Impl;
using MyNotes.Service;
using MyNotes.Service.Impl;
using System.Windows;

namespace MyNotes.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            ////if (ViewModelBase.IsInDesignModeStatic)
            ////{
            ////    // Create design time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DesignDataService>();
            ////}
            ////else
            ////{
            ////    // Create run time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DataService>();
            ////}

            RegisterRepositories();
            RegisterServices();

            SimpleIoc.Default.Register<LoginViewModel>();
            SimpleIoc.Default.Register<NoteListViewModel>();
            SimpleIoc.Default.Register<AddNoteViewModel>();
            SimpleIoc.Default.Register<EditNoteViewModel>();
            SimpleIoc.Default.Register<ConfigurationViewModel>();
        }

        private void RegisterRepositories()
        {
            if (SimpleIoc.Default.IsRegistered<IConfigurationRepository>() == false)
            {
                SimpleIoc.Default.Register<IConfigurationRepository, ConfigurationSqLiteRepositoryImpl>();
            }

            if (SimpleIoc.Default.IsRegistered<INoteRepository>() == false)
            {
                SimpleIoc.Default.Register<INoteRepository, NoteSqLiteRepositoryImpl>();
            }
        }

        private void RegisterServices()
        { 
            if (SimpleIoc.Default.IsRegistered<IConfigurationService>() == false)
            {
                SimpleIoc.Default.Register<IConfigurationService, ConfigurationServiceImpl>();
            }

            if (SimpleIoc.Default.IsRegistered<INoteService>() == false)
            {
                SimpleIoc.Default.Register<INoteService, NoteServiceImpl>();
            }

            if (SimpleIoc.Default.IsRegistered<ILoginService>() == false)
            {
                SimpleIoc.Default.Register<ILoginService, LoginServiceImpl>();
            }
        }


        public LoginViewModel Login
        {
            get 
            {
                return ServiceLocator.Current.GetInstance<LoginViewModel>();
            }
        }

        public NoteListViewModel NoteList
        {
            get
            {
                return ServiceLocator.Current.GetInstance<NoteListViewModel>();
            }
        }

        public AddNoteViewModel AddNote
        {
            get 
            {
                return ServiceLocator.Current.GetInstance<AddNoteViewModel>();
            }
        }

        public EditNoteViewModel EditNote
        {
            get 
            {
                return ServiceLocator.Current.GetInstance<EditNoteViewModel>();
            }
        }

        public ConfigurationViewModel Configuration
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ConfigurationViewModel>();
            }
        }
        
        public static void Cleanup()
        {
            var viewModelLocator = (ViewModelLocator)Application.Current.Resources["Locator"];
            viewModelLocator.Login.Cleanup();

            Messenger.Reset();

            ((SqLiteBaseRepository)ServiceLocator.Current.GetInstance<IConfigurationRepository>()).Dispose();
        }
    }
}