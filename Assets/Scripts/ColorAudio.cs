using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Get : MonoBehaviour {
 public AudioSource audioSource;
 float[] samples;
 public int partes = 1024;
 
 public List<Image> m;
 public List<Color> c;
 
 void Start () {
  samples = new float[partes];
 }
 
 float Volume()
 {
  float volume = 0;
  if(audioSource.isPlaying)
  {
   for(int canal=0; canal<2; canal++)
   {
    audioSource.GetOutputData(samples,canal);
    for(int i= 0; i<partes; i++)
    {
     volume += Mathf.Abs(samples[i]);
    }
   }
   volume = volume/partes;
  }
  return volume;
 }
 public float amplitude;
 public float speed;
 void Update(){
  amplitude = Volume();
  
  for(int i = 0; i < m.Count; i++){
   if(amplitude <= 0.2f){
    m[i].color = Color.Lerp(m[i].color,c[0],speed * Time.deltaTime);
   }
   
   if(amplitude > 0.2f && amplitude <= 0.4f){
    m[i].color = Color.Lerp(m[i].color,c[1],speed * Time.deltaTime);
   }
   
   if(amplitude > 0.4f && amplitude <= 0.6f){
    m[i].color = Color.Lerp(m[i].color,c[2],speed * Time.deltaTime);
   }
   
   if(amplitude > 0.6f && amplitude <= 0.8f){
    m[i].color = Color.Lerp(m[i].color,c[3],speed * Time.deltaTime);
   }
   
   if(amplitude >= 0.9f){
    m[i].color = Color.Lerp(m[i].color,c[4],speed * Time.deltaTime);
   }
  }
 }
 
}