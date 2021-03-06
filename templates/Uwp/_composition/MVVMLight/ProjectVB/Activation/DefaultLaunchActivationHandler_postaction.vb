﻿'{[{
Imports Param_RootNamespace.ViewModels
'}]}
Namespace Activation
    Friend Class DefaultLaunchActivationHandler
        Inherits ActivationHandler(Of LaunchActivatedEventArgs)
'{[{

        Private ReadOnly _navElement As string

        Private ReadOnly Property NavigationService As NavigationServiceEx
            Get
                Return ViewModelLocator.Current.NavigationService
            End Get
        End Property

        Public Sub New(navElement As Type)
            _navElement = navElement.FullName
        End Sub
'}]}
    End Class
End Namespace
