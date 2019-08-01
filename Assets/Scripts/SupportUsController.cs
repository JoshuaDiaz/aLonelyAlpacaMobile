﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Monetization;
using UnityEngine.UI;

public class SupportUsController : MonoBehaviour
{
    [SerializeField] GameObject supportUsMenu;
    [SerializeField] GameObject supportOptionsMenu;
    [SerializeField] GameObject donateMenu;
    public RectTransform supportButtTransform;
    /* start and end positions of the support buttons */
    public Vector3 unselectedPosition = new Vector3(-50.0f, -37.0f, 0);
    public Vector3 selectedPosition = new Vector3(-50.0f, -55.0f, 0);
    /* state of whether button is coming down or going up */
    private bool comingDown;
    private bool goingUp;
    private float lerp_timer;
    string appleID = "3203751";
    string googleID = "3203750";
    string videoAdID = "rewardedVideo";

    // Start is called before the first frame update
    void Start()
    {
        // TODO: switch to false when live
        Monetization.Initialize(googleID, true);
        Monetization.Initialize(appleID, true);
        supportUsMenu.SetActive(false);
        supportOptionsMenu.SetActive(false);
        donateMenu.SetActive(false);
    }

    /**
     * Used for the button entering the support screen,
     * and both back buttons in the support screens (on options and donate page)
     */
    public void toggleMenu()
    {
        lerp_timer = 0;
        if (!supportUsMenu.activeSelf) // no support screen open -> open options
        {
            supportUsMenu.SetActive(true);
            supportOptionsMenu.SetActive(true);
            donateMenu.SetActive(false);
            comingDown = true;
            goingUp = false;
        } else if(donateMenu.activeSelf) // donate screen open -> go to options
        {
            supportOptionsMenu.SetActive(true);
            donateMenu.SetActive(false);
        } else // support options open -> close support screen
        {
            supportUsMenu.SetActive(false);
            supportOptionsMenu.SetActive(false);
            donateMenu.SetActive(false);
            comingDown = false;
            goingUp = true;
        }
    }

    /** Called every frame */
    void Update () {
        if(comingDown) {
            lerp_timer += 2 * Time.deltaTime;
			supportButtTransform.anchoredPosition = Vector3.Lerp(supportButtTransform.anchoredPosition, selectedPosition, lerp_timer);
        }
        else if(goingUp) {
            lerp_timer += 2 * Time.deltaTime;
			supportButtTransform.anchoredPosition = Vector3.Lerp(supportButtTransform.anchoredPosition, unselectedPosition, lerp_timer);
        }
        else {
            lerp_timer = 0;
        }
    }
    /**
     * Used for support options page -> donate page
     */
    public void goDonatePage()
    {
        supportOptionsMenu.SetActive(false);
        donateMenu.SetActive(true);
    }

    public void showAd()
    {
        if (Monetization.IsReady(videoAdID))
        {
            ShowAdPlacementContent ad = null;
            ad = Monetization.GetPlacementContent(videoAdID) as ShowAdPlacementContent;

            if (ad != null)
            {
                ad.Show();
            }
        }
    }

    public void leaveReview()
    {
        // TODO: take to play/app store
    }
}
