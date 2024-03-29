﻿// Object Follow|Utilities|90110
namespace VRTK
{
    using UnityEngine;
    /// <summary>
    /// Abstract class that allows to change one game object's properties to follow another game object.
    /// </summary>
    public abstract class VRTK_ObjectFollow : MonoBehaviour
    {
        [Header("Object Settings")]

        [Tooltip("The game object to follow. The followed property values will be taken from this one.")]
        public GameObject gameObjectToFollow;
        [Tooltip("The game object to change the property values of. If left empty the game object this script is attached to will be changed.")]
        public GameObject gameObjectToChange;

        [Header("Position Settings")]

        [Tooltip("Whether to follow the position of the given game object.")]
        public bool followsPosition = true;
        [Tooltip("Whether to smooth the position when following `gameObjectToFollow`.")]
        public bool smoothsPosition;
        [Tooltip("The maximum allowed distance between the unsmoothed source and the smoothed target per frame to use for smoothing.")]
        public float maxAllowedPerFrameDistanceDifference = 0.003f;
        /// <summary>
        /// The position that results by following `gameObjectToFollow`.
        /// </summary>
        public Vector3 targetPosition { get; private set; }

        [Header("Rotation Settings")]

        [Tooltip("Whether to follow the rotation of the given game object.")]
        public bool followsRotation = true;
        [Tooltip("Whether to smooth the rotation when following `gameObjectToFollow`.")]
        public bool smoothsRotation;
        [Tooltip("The maximum allowed angle between the unsmoothed source and the smoothed target per frame to use for smoothing.")]
        public float maxAllowedPerFrameAngleDifference = 1.5f;
        /// <summary>
        /// The rotation that results by following `gameObjectToFollow`.
        /// </summary>
        public Quaternion targetRotation { get; private set; }

        [Header("Scale Settings")]

        [Tooltip("Whether to follow the scale of the given game object.")]
        public bool followsScale = true;
        [Tooltip("Whether to smooth the scale when following `gameObjectToFollow`.")]
        public bool smoothsScale;
        [Tooltip("The maximum allowed size between the unsmoothed source and the smoothed target per frame to use for smoothing.")]
        public float maxAllowedPerFrameSizeDifference = 0.003f;
        /// <summary>
        /// The scale that results by following `gameObjectToFollow`.
        /// </summary>
        public Vector3 targetScale { get; private set; }
        public float YDistance = 4;
        public float XDistance = 0;
        public float ZDistance = 4;
        /// <summary>
        /// Follow `gameObjectToFollow` using the current settings.
        /// </summary>
        public virtual void Follow()
        {
            
            if (gameObjectToFollow == null)
            {
                return;
            }

            if (followsPosition)
            {
                FollowPosition();
            }

            if (followsRotation)
            {
                FollowRotation();
            }

            if (followsScale)
            {
                FollowScale();
            }
        }

        protected virtual void OnEnable()
        {
            gameObjectToChange = gameObjectToChange != null ? gameObjectToChange : gameObject;
        }

        protected virtual void OnValidate()
        {
            maxAllowedPerFrameDistanceDifference = Mathf.Max(0.0001f, maxAllowedPerFrameDistanceDifference);
            maxAllowedPerFrameAngleDifference = Mathf.Max(0.0001f, maxAllowedPerFrameAngleDifference);
            maxAllowedPerFrameSizeDifference = Mathf.Max(0.0001f, maxAllowedPerFrameSizeDifference);
        }

        protected abstract Vector3 GetPositionToFollow();

        protected abstract void SetPositionOnGameObject(Vector3 newPosition);

        protected abstract Quaternion GetRotationToFollow();

        protected abstract void SetRotationOnGameObject(Quaternion newRotation);

        protected virtual Vector3 GetScaleToFollow()
        {
            return gameObjectToFollow.transform.localScale;
        }

        protected virtual void SetScaleOnGameObject(Vector3 newScale)
        {
            gameObjectToChange.transform.localScale = newScale;
        }

        protected virtual void FollowPosition()
        {
            Vector3 positionToFollow = GetPositionToFollow();
            Vector3 newPosition;

            if (smoothsPosition)
            {
                float y = this.gameObject.transform.rotation.y;
                if (y > 180 && y < 0)
                {
                    ZDistance = Mathf.Abs(ZDistance) * -1;
                    XDistance = Mathf.Abs(XDistance) * -1;
                    
                }
                else
                {
                    ZDistance = Mathf.Abs(ZDistance);
                    XDistance = Mathf.Abs(XDistance);

                }
                float alpha = Mathf.Clamp01(Vector3.Distance(targetPosition, positionToFollow) / maxAllowedPerFrameDistanceDifference);
                newPosition = Vector3.Lerp(targetPosition, positionToFollow, alpha);
                newPosition.y = YDistance;
               // newPosition.x = -32.2f;
            }
            else
            {
                newPosition = positionToFollow;
            }

            targetPosition = newPosition;
            SetPositionOnGameObject(newPosition);
        }

        protected virtual void FollowRotation()
        {
            Quaternion rotationToFollow = GetRotationToFollow();
            Quaternion newRotation;

            if (smoothsRotation)
            {
                float alpha = Mathf.Clamp01(Quaternion.Angle(targetRotation, rotationToFollow) / maxAllowedPerFrameAngleDifference);
                newRotation = Quaternion.Lerp(targetRotation, rotationToFollow, alpha);
                newRotation.x = 0;
                newRotation.z = 0;
            }
            else
            {
                newRotation = rotationToFollow;
            }

            targetRotation = newRotation;
            SetRotationOnGameObject(newRotation);
        }

        protected virtual void FollowScale()
        {
            Vector3 scaleToFollow = GetScaleToFollow();
            Vector3 newScale;

            if (smoothsScale)
            {
                float alpha = Mathf.Clamp01(Vector3.Distance(targetScale, scaleToFollow) / maxAllowedPerFrameSizeDifference);
                newScale = Vector3.Lerp(targetScale, scaleToFollow, alpha);
            }
            else
            {
                newScale = scaleToFollow;
            }

            targetScale = newScale;
            SetScaleOnGameObject(newScale);
        }
    }
}