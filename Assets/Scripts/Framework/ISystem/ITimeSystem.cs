﻿using System;
using System.Collections.Generic;
using QFramework;
using UnityEngine;

namespace MyGameNamespace
{
    public interface ITimeSystem : QFISystem
    {
        float CurrentSeconds { get; }
        void AddDelayTask(float seconds, Action onFinish);
        public void CancelDelayTask(Action onFinish);
        public void AllCancelDelayTask();
    }

    public enum DelayTaskState
    {
        NotStart,
        Started,
        Finish
    }

    public class DelayTask
    {
        public float Seconds { get; set; }
        public Action OnFinish { get; set; }
        public float StartSeconds { get; set; }
        public float FinishSeconds { get; set; }
        public DelayTaskState State { get; set; }
    }

    public class TimeSystem : AbstractSystem, ITimeSystem
    {
        public class TimeSystemUpdateBehaviour : MonoBehaviour
        {
            public event Action OnUpdate;

            private void Update()
            {
                OnUpdate?.Invoke();
            }
        }

        protected override void OnInit()
        {
            var updateBehaviourGameObj = new GameObject(nameof(TimeSystemUpdateBehaviour));
            UnityEngine.Object.DontDestroyOnLoad(
                updateBehaviourGameObj); // 如果需要销毁，可以缓存为成员变量
            var updateBehaviour = updateBehaviourGameObj.AddComponent<TimeSystemUpdateBehaviour>();
            updateBehaviour.OnUpdate += OnUpdate;
        }

        public float CurrentSeconds { get; private set; } = 0.0f;
        private LinkedList<DelayTask> mDelayTasks = new LinkedList<DelayTask>();

        private void OnUpdate()
        {
            CurrentSeconds += Time.deltaTime;
            if (mDelayTasks.Count > 0)
            {
                var currentNode = mDelayTasks.First;
                while (currentNode != null)
                {
                    var delayTask = currentNode.Value;
                    var nextNode = currentNode.Next;
                    if (delayTask.State == DelayTaskState.NotStart)
                    {
                        delayTask.State = DelayTaskState.Started;
                        delayTask.StartSeconds = CurrentSeconds;
                        delayTask.FinishSeconds = CurrentSeconds + delayTask.Seconds;
                    }
                    else if (delayTask.State == DelayTaskState.Started)
                    {
                        if (CurrentSeconds > delayTask.FinishSeconds)
                        {
                            delayTask.State = DelayTaskState.Finish;
                            delayTask.OnFinish.Invoke();
                            delayTask.OnFinish = null;
                            mDelayTasks.Remove(
                                currentNode); // 删除节点
                        }
                    }

                    currentNode = nextNode;
                }
            }
        }

        public void CancelDelayTask(Action onFinish)
        {
            var currentNode = mDelayTasks.First;
            while (currentNode != null)
            {
                var delayTask = currentNode.Value;
                var nextNode = currentNode.Next;
                if (delayTask.OnFinish == onFinish)
                {
                    // 取消延迟任务
                    delayTask.OnFinish = null;
                    mDelayTasks.Remove(currentNode);

                    Debug.Log("取消延迟执行的委托" + currentNode.Value);
                    break; // 找到匹配的任务后，跳出循环
                }
                currentNode = nextNode;
            }
        }

        public void AddDelayTask(float seconds, Action onFinish)
        {
            var delayTask = new DelayTask()
                { Seconds = seconds, OnFinish = onFinish, State = DelayTaskState.NotStart, };
            mDelayTasks.AddLast(new LinkedListNode<DelayTask>(delayTask));
        }

        public void AllCancelDelayTask()
        {

        mDelayTasks.Clear(); 
        }
    }
}