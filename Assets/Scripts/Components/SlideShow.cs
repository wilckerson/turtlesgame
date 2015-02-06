using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public enum SlideShowState
{
		//Start,
		FadeIn,
		Delay,
		FadeOut,
		Stoped
}

public class SlideShow : MonoBehaviour
{

		public delegate void SlideShowStopEvent ();

		public event SlideShowStopEvent OnSlideShowStop;

		public List<Graphic> Slides;
		public float DelaySeconds = 3;
		public float TransitionVelocity = 0.1f;
		public bool AutoStart = true;
		int slidesCount = 0;
		int currentSlide = 0;
		float currentAlpha = 0;
		SlideShowState state = SlideShowState.Stoped;
		float startTime = 0;

		// Use this for initialization
		void Start ()
		{
				//If any slide
				if (Slides != null && Slides.Count > 0) {

						//Set slides opacity to zero
						foreach (var slide in Slides) {
								if (slide == null) {
										throw new UnityException ("You must set all slides.");
								}
								slide.color = new Color (slide.color.r, slide.color.g, slide.color.b, 0);
								slide.gameObject.SetActive (true);
						}

						if (AutoStart) {
								//Start the transitions
								Play ();
						}
				}
		}
	
		// Update is called once per frame
		void Update ()
		{

				switch (state) {
				case SlideShowState.FadeIn:
						FadeIn ();
						break;

				case SlideShowState.Delay:
						if (Time.time - startTime > DelaySeconds) {
								state = SlideShowState.FadeOut;
						}
						break;

				case SlideShowState.FadeOut:
						FadeOut ();
						break;


				default:
						break;
				}
				//Debug.Log (currentSlide);
				//Debug.Log (currentAlpha);

		}

		void FadeIn ()
		{
				currentAlpha += TransitionVelocity * Time.deltaTime;
				if (currentAlpha > 1) {
						currentAlpha = 1;
						state = SlideShowState.Delay;
						startTime = Time.time;
				}
				
				var slide = Slides [currentSlide];
				slide.color = new Color (slide.color.r, slide.color.g, slide.color.b, currentAlpha);

		}

		void FadeOut ()
		{
				currentAlpha -= TransitionVelocity * Time.deltaTime;
				if (currentAlpha < 0) {
						currentAlpha = 0;
						currentSlide++;
						if (currentSlide < Slides.Count) {
								state = SlideShowState.FadeIn;
						} else {
								state = SlideShowState.Stoped;
								currentSlide = Slides.Count - 1;
								if (OnSlideShowStop != null) {
										OnSlideShowStop ();
								}
						}
				}
		
				var slide = Slides [currentSlide];
				slide.color = new Color (slide.color.r, slide.color.g, slide.color.b, currentAlpha);
		
		}

		public void Play ()
		{
				currentSlide = 0;
				currentAlpha = 0;
				state = SlideShowState.FadeIn;
		}
}
