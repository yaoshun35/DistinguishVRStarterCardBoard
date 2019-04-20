// (c) Copyright HutongGames, LLC 2010-2013. All rights reserved.
using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("iTween")]
	[Tooltip("Adds to a GameObject's scale over time.")]
	public class iTweenScaleAdd: iTweenFsmAction
	{
		[RequiredField]
		public FsmOwnerDefault gameObject;
		
		[Tooltip("iTween ID. If set you can use iTween Stop action to stop it by its id.")]
		public FsmString id;
		
		[RequiredField]
		[Tooltip("A vector that will be added to the GameObjects scale.")]
		public FsmVector3 vector;
		[Tooltip("The time in seconds the animation will take to complete.")]
		public FsmFloat time;
		[Tooltip("The time in seconds the animation will wait before beginning.")]
		public FsmFloat delay;
		[Tooltip("Can be used instead of time to allow animation based on speed. When you define speed the time variable is ignored.")]
		public FsmFloat speed;
		[Tooltip("The shape of the easing curve applied to the animation.")]
		public iTween.EaseType easeType = iTween.EaseType.linear;
		[Tooltip("The type of loop to apply once the animation has completed.")]
		public iTween.LoopType loopType = iTween.LoopType.none;
		
				
		public override void Reset()
		{
			base.Reset();
			id = new FsmString{UseVariable = true};
			time = 1f;
			delay = 0f;
			loopType = iTween.LoopType.none;
			vector = new FsmVector3 { UseVariable = true };
			speed = new FsmFloat { UseVariable = true };
		}

		public override void OnEnter()
		{
			base.OnEnteriTween(gameObject);
			if(loopType != iTween.LoopType.none) base.IsLoop(true);
			DoiTween();	
		}
		
		public override void OnExit(){
			base.OnExitiTween(gameObject);
		}
				
		void DoiTween()
		{
			GameObject go = Fsm.GetOwnerDefaultTarget(gameObject);
			if (go == null) return;
			
			// init position
			
			Vector3 amount = Vector3.zero;
			if (vector.IsNone) { 
				
			} else {
				amount = vector.Value;
			}

			itweenType = "scale";
			iTween.ScaleAdd(go, iTween.Hash(
			                              "amount", amount,
			                              "name", id.IsNone ? "" : id.Value,  
			                              speed.IsNone ? "time" : "speed", speed.IsNone ? time.IsNone ? 1f : time.Value : speed.Value,
			                              "delay", delay.IsNone ? 0f : delay.Value,
			                              "easetype", easeType,
			                              "looptype", loopType,
				
										  "oncompleteaction",(Action) ( () => { OnCompleteAction();} ),
										  "onstartaction",(Action) ( () => { OnStartAction();} ),
				
										  /* Jean Fabre <jean@hutonggames.com> : removed because obsolete, now use oncompleteaction and onstartaction params
			                              "oncomplete", "iTweenOnComplete",
			                              "oncompleteparams", itweenID,
			                              "onstart", "iTweenOnStart",
			                              "onstartparams", itweenID,
			                              */
				
			                              "ignoretimescale", realTime.IsNone ? false : realTime.Value  
			                              )); 
		}
	}
}