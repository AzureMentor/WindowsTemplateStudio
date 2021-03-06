﻿using System;
using System.Linq;
using Caliburn.Micro;

using Windows.System;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Navigation;

using Param_ItemNamespace.Helpers;
using Param_ItemNamespace.Services;
using Param_ItemNamespace.Core.Models;
using Param_ItemNamespace.Core.Services;

namespace Param_ItemNamespace.ViewModels
{
    public class ImageGalleryViewDetailViewModel : Screen
    {
        private readonly INavigationService _navigationService;
        private readonly IConnectedAnimationService _connectedAnimationService;
        private SampleImage _selectedImage;

        public SampleImage SelectedImage
        {
            get => _selectedImage;
            set
            {
                Param_Setter(ref _selectedImage, value);
                ImagesNavigationHelper.UpdateImageId(ImageGalleryViewViewModel.ImageGalleryViewSelectedIdKey, SelectedImage.ID);
            }
        }

        public string ID { get; set; }

        public BindableCollection<SampleImage> Source { get; } = new BindableCollection<SampleImage>();

        public ImageGalleryViewDetailViewModel(INavigationService navigationService, IConnectedAnimationService connectedAnimationService)
        {
            _navigationService = navigationService;
            _connectedAnimationService = connectedAnimationService;
        }

        protected override void OnInitialize()
        {
            base.OnInitialize();

            // TODO WTS: Replace this with your actual data
            Source.AddRange(SampleDataService.GetGallerySampleData());
        }

        public void Initialize(NavigationMode navigationMode)
        {
            if (!string.IsNullOrEmpty(ID) && navigationMode == NavigationMode.New)
            {
                SelectedImage = Source.First(i => i.ID == ID);
            }
            else
            {
                var selectedImageId = ImagesNavigationHelper.GetImageId(ImageGalleryViewViewModel.ImageGalleryViewSelectedIdKey);
                if (!string.IsNullOrEmpty(selectedImageId))
                {
                    SelectedImage = Source.FirstOrDefault(i => i.ID == selectedImageId);
                }
            }
        }

        public void OnPageKeyDown(KeyRoutedEventArgs e)
        {
            if (e.Key == VirtualKey.Escape && _navigationService.CanGoBack)
            {
                _navigationService.GoBack();
                e.Handled = true;
            }
        }

        public void UpdateConnectedAnimation()
        {
            _connectedAnimationService.SetListDataItemForNextConnectedAnnimation(SelectedImage);
            ImagesNavigationHelper.RemoveImageId(ImageGalleryViewViewModel.ImageGalleryViewSelectedIdKey);
        }
    }
}
