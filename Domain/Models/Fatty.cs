using System;
using System.Collections.Generic;
using System.Linq;

namespace FatDairy.Domain.Models
{
    public class Fatty : IEntity
    {
        
        protected readonly List<WeightChangeLogItem> _changeLog;

        protected internal Fatty(UserInfo userInfo,
            bool hideFoodTrack,
            bool hideAge,
            bool hideEmail,
            double currentWeigth,
            double desiredWeigth,
            double height,
            Trainer trainer = null,
            IEnumerable<WeightChangeLogItem> changeLog = null)
        {
            HideFoodTrack = hideFoodTrack;
            HideAge = hideAge;
            HideEmail = hideEmail;
            Trainer = trainer;
            _changeLog = changeLog.ToList() ?? new List<WeightChangeLogItem>();
            CurrentWeigth = currentWeigth > 0 ? currentWeigth : throw new InvalidOperationException("Current weight cannot be below zero");
            DesiredWeigth = desiredWeigth > 0 ? desiredWeigth : throw new InvalidOperationException("Desired weight cannot be below zero");
            Heigth = height > 0 ? height : throw new InvalidOperationException("Height cannot be below zero");
        }

        public int Id { get; set; }
        public bool HideAge { get; protected set; }
        public bool HideEmail { get; protected set; }
        public bool HideFoodTrack { get; protected set; }
        public UserInfo UserInfo { get; protected set; }

        public Trainer Trainer { get; protected set; }
        public double CurrentWeigth { get; protected set; }
        public double DesiredWeigth { get; protected set; }
        public double Heigth { get; protected set; }
        public IEnumerable<WeightChangeLogItem> WeightChangeLog => _changeLog.AsEnumerable();

        public void ChangeUserInfo(UserInfo userInfo)
        {
            UserInfo = userInfo;
        }

        public void ChangeCurrentWeight(int newWeight, DateTime? date)
        {
            var changeLogItem = new WeightChangeLogItem()
            {
                Date = date ?? DateTime.Now,
                OldValue = CurrentWeigth,
                NewValue = newWeight
            };
            _changeLog.Add(changeLogItem);

            CurrentWeigth = newWeight;
        }

        public void ChangeDesiredWeight(int newWeight, DateTime? date)
        {
            DesiredWeigth = newWeight;
        }

        public void ChangeTrainer(Trainer trainer)
        {
            Trainer = trainer;
        }

    }
}
