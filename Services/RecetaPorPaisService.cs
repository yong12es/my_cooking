﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using mycooking.Models;

namespace mycooking.Services
{
    public class RecetaPorPaisService : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private static RecetaPorPaisService _instance;
        public static RecetaPorPaisService Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new RecetaPorPaisService();
                }
                return _instance;
            }
        }

        private ObservableCollection<Pais> _paises = new ObservableCollection<Pais>();
        public ObservableCollection<Pais> Paises
        {
            get { return _paises; }
            set { 
                _paises = value;
                OnPropertyChanged(nameof(Paises));
            }
        }

        private ObservableCollection<Receta> _recetas = new ObservableCollection<Receta>();
        public ObservableCollection<Receta> Recetas
        {
            get { return _recetas; }
            set { 
                _recetas = value;
                OnPropertyChanged(nameof(Recetas));
            }
        }

        public void AgregarPais(Pais pais)
        {
            Paises.Add(pais);
            OnPropertyChanged(nameof(Paises));
        }

        public void AgregarReceta(Receta receta)
        {
            _recetas.Add(receta);
            OnPropertyChanged(nameof(Recetas));
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        private bool _isRecipeSelected;
        public bool IsRecipeSelected
        {
            get { return _isRecipeSelected; }
            set
            {
                _isRecipeSelected = value;
                OnPropertyChanged(nameof(IsRecipeSelected));
            }
        }
    }
}