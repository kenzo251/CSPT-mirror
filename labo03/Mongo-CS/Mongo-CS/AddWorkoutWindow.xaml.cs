﻿using Globals;
using Logicalaag;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace EF_Core {
    /// <summary>
    /// Interaction logic for AddWorkoutWindow.xaml
    /// </summary>
    public partial class AddWorkoutWindow : Window {
        public MainWindow parent;
        public IDataPreProcessor dpp;
        public Workout workout;
        private int updateIdx;
        public AddWorkoutWindow() {
            InitializeComponent();
            updateIdx = -1;
        }

        public void SetWorkout(Workout workout, int idx) {
            this.workout = workout;
            coaches.SelectedItem = workout.Coach;
            type.SelectedItem = workout.Type;
            pools.SelectedItem = workout.Swimmingpool;
            date.SelectedDate = workout.Schedule.Date;
            hours.Text = workout.Schedule.Hour.ToString();
            minutes.Text = workout.Schedule.Minute.ToString();
            durationTxt.Text = workout.Duration.ToString();
            updateIdx = idx;
        }

        private void clickOk(object sender, RoutedEventArgs e) {
            try {
                bool insert = false;
                if (workout == null) {
                    insert = true;
                    workout = new Workout();
                }
                if (coaches.SelectedItem == null) throw new Exception("no coach selected");
                if (type.SelectedItem == null) throw new Exception("no type selected");
                if (pools.SelectedItem == null) throw new Exception("no pool selected");
                if (date.SelectedDate == null) throw new Exception("no date selected");

                int duration = int.Parse(durationTxt.Text);
                int hour = int.Parse(hours.Text);
                int minute = int.Parse(minutes.Text);
                DateTime dt = (DateTime)date.SelectedDate;
                dt = new DateTime(dt.Year, dt.Month, dt.Day, hour, minute, 0);

                workout.Coach = (Coach)coaches.SelectedItem;
                workout.Type = (WorkoutType)type.SelectedItem;
                workout.Swimmingpool = (SwimmingPool)pools.SelectedItem;
                workout.Duration = duration;
                workout.Schedule = dt;

                if (insert) {
                    dpp.AddWorkout(workout);
                    parent.workouts.Add(workout);
                    parent.updateWorkouts();
                }
                else {
                    dpp.UpdateWorkout(workout);
                    parent.UpdateWorkoutAt(workout, updateIdx);
                }
                this.Close();
            }
            catch (Exception ex) {
                errorlabel.Content = ex.Message;
            }
        }
    }
}
