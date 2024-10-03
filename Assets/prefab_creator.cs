using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class prefab_creator : MonoBehaviour
{
    [SerializeField] private GameObject dragonprefab;
    [SerializeField] private Vector3 prefaboffset;

    private GameObject dragon;
    private ARTrackedImageManager aRTrackedImageManager;

    private void OnEnable()
    {
        aRTrackedImageManager = gameObject.GetComponent<ARTrackedImageManager>();
        aRTrackedImageManager.trackedImagesChanged += OnImagechange;
    }

    private void OnImagechange(ARTrackedImagesChangedEventArgs obj)
    {
        foreach(ARTrackedImage image in obj.added)
        {
            dragon = Instantiate(dragonprefab, image.transform);
            dragon.transform.position += prefaboffset;
        }
    }
}
