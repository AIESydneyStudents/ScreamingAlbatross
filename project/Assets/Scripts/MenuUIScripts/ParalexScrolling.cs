using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

[Serializable]
public class ParalexScrollingLayer
{
    public Sprite sprite;
    public Vector2 scrollSpeed = Vector2.zero;

    [NonSerialized] public Vector2 offset = Vector2.zero;
    
    [NonSerialized] public Material material;
}

public class ParalexScrolling : MonoBehaviour
{
    public Shader shader;
    public List<ParalexScrollingLayer> layers = new List<ParalexScrollingLayer>();

    // Start is called before the first frame update
    void Start()
    {
        foreach (var layer in layers)
        {
            CreateLayerObject(layer);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        foreach (var layer in layers)
        {
            UpdateLayerObject(layer);
        }
    }

    void CreateLayerObject(ParalexScrollingLayer layer)
    {
        var mat = new Material(shader);
        mat.SetTexture("_MainTex", layer.sprite.texture);

        var layerObj = new GameObject();
        var image = layerObj.AddComponent<Image>();
        image.sprite = layer.sprite;
        image.material = mat;

        var rect = layerObj.GetComponent<RectTransform>();
        rect.pivot = Vector2.zero;
        rect.anchorMin = Vector2.zero;
        rect.anchorMax = Vector2.zero;
        rect.sizeDelta = layer.sprite.textureRect.size;

        rect.SetParent(transform);        
        layerObj.SetActive(true);

        // update the layer with the object components
        layer.material = mat;
        
    }

    void UpdateLayerObject(ParalexScrollingLayer layer)
    {
        layer.offset += layer.scrollSpeed * Time.deltaTime;
        layer.material.SetFloat("MyXOffset", layer.offset.x);
        layer.material.SetFloat("MyYOffset", layer.offset.y);

        // Move all of the objects
        //foreach(var obj in layer.objects)
        //{
        //    obj.transform.position += layer.scrollSpeed * Time.deltaTime;  
        //}

        //// reset objects positions if needed.
        //foreach (var obj in layer.objects)
        //{
        //    // has the sprite moved out of the view
        //    if (obj.transform.localPosition.x + imgWidth < rectTransform.rect.xMin)
        //    {
        //        float xPos = layer.objects.Select(z => z.transform.rect.position.x + imgWidth).Max();
        //        obj.transform.position = new Vector3(xPos, obj.transform.position.y, obj.transform.position.z);
        //    }
        //}
    }
}
