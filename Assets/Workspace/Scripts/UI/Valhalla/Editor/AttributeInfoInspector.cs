﻿// <copyright file="AttributeInfoInspector.cs" company="Maxim Mikulski">Copyright (c) 2016 All Rights Reserved</copyright>
// <author>Maxim Mikulski</author>

using UnityEngine;
using UnityEditor;

using V4F.Character;

namespace V4F.UI.Valhalla
{

    [CustomEditor(typeof(AttributeInfo)), InitializeOnLoad]
    public class AttributeInfoInspector : Editor
    {
        private static readonly GUIContent[] __content = null;
        private static readonly AttributeType[] __attributes = null;
        private AttributeInfo _self;

        static AttributeInfoInspector()
        {
            __content = new GUIContent[]
            {
                new GUIContent("Dispatcher"),
                new GUIContent("Attribute"),
                new GUIContent("Title UI"),
                new GUIContent("Value UI"),
                new GUIContent("Title"),
                new GUIContent("Percent"),                
            };

            __attributes = System.Enum.GetValues(typeof(AttributeType)) as AttributeType[];
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            var statsProp = serializedObject.FindProperty("_dispatcher");
            EditorGUILayout.PropertyField(statsProp, __content[0]);            

            var titleProp = serializedObject.FindProperty("_title");
            titleProp.stringValue = DrawLocalization(__content[4], titleProp.stringValue);

            var titleUIProp = serializedObject.FindProperty("_titleUI");
            EditorGUILayout.PropertyField(titleUIProp, __content[2]);

            var typeProp = serializedObject.FindProperty("_type");
            typeProp.enumValueIndex = (int)((AttributeType)EditorGUILayout.EnumPopup(__content[1], __attributes[typeProp.enumValueIndex]));

            var valueUIProp = serializedObject.FindProperty("_valueUI");
            EditorGUILayout.PropertyField(valueUIProp, __content[3]);

            var percentProp = serializedObject.FindProperty("_percent");
            EditorGUILayout.PropertyField(percentProp, __content[5]);

            var type2Prop = serializedObject.FindProperty("_type2");
            type2Prop.enumValueIndex = (int)((AttributeType)EditorGUILayout.EnumPopup(__content[1], __attributes[type2Prop.enumValueIndex]));

            var valueUI2Prop = serializedObject.FindProperty("_valueUI2");
            EditorGUILayout.PropertyField(valueUI2Prop, __content[3]);

            var percent2Prop = serializedObject.FindProperty("_percent2");
            EditorGUILayout.PropertyField(percent2Prop, __content[5]);

            if (GUI.changed)
            {
                serializedObject.ApplyModifiedProperties();
                EditorUtility.SetDirty(_self);
            }
        }

        private string DrawLocalization(GUIContent content, string key)
        {            
            var selectedIndex = Localization.GetKeyIndex(key);
            var select = EditorGUILayout.Popup(content.text, selectedIndex, Localization.keys);
            if (select != selectedIndex)
            {
                return Localization.GetKey(select);
            }

            return key;
        }

        private void OnEnable()
        {
            _self = target as AttributeInfo;
        }
    }
	
}
