using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour 
{

	public float g_Speed;
	public float g_TurnSpeed;
	public float g_Offset;
	private float m_CurrentAngle;
	private float m_RequestedAngle;
	private Vector3 m_Movement;
	//public GUIText countText;
	//public GUIText winText;
	//private int count;
	
	void Start()
	{
		//count = 0;	
		//SetCountText();
		//winText.text="";
	}
	void FixedUpdate()
	{
		
		//print ("-------------------------------------------------");
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");

		//TODO: Convert this so full range of angles accessable via click/touch
		if(moveVertical==0 && moveHorizontal ==0)
		{
			m_RequestedAngle =m_CurrentAngle;
		}
		else
		{
			if(moveVertical>0)
			{
				m_RequestedAngle = 0.0f;
			}
			else if(moveVertical<0)
			{
				m_RequestedAngle = 180.0f;
			}

			if(moveHorizontal>0)
			{
				m_RequestedAngle = 270.0f;
			}
			else if (moveHorizontal<0)
			{
				m_RequestedAngle = 90.0f;
			}

			m_CurrentAngle = transform.eulerAngles.z;
			float upperOffset = m_RequestedAngle + g_Offset;
			float lowerOffset = m_RequestedAngle - g_Offset;
			float tempAngle = 0.0f;
			bool tempUsed = false;
			//upperOffset = CheckWithinAngleRange(upperOffset);
			//lowerOffset = CheckWithinAngleRange(lowerOffset);
			if(upperOffset>360.0f)
			{
				tempAngle = m_CurrentAngle+360;
				tempUsed=true;
			}
			if(lowerOffset<0.0f)
			{
				tempAngle = m_CurrentAngle-360;
				tempUsed=true;
			}

			if(!tempUsed?
			   !(upperOffset>m_CurrentAngle && m_CurrentAngle>lowerOffset)
			   		:
			   !(upperOffset>tempAngle && tempAngle>lowerOffset))
			{
				float step = g_TurnSpeed*Time.deltaTime;
				float antiClockWiseTurn = m_CurrentAngle - m_RequestedAngle;
				float clockWiseTurn = m_RequestedAngle - m_CurrentAngle;
				
				clockWiseTurn = CheckWithinAngleRange(clockWiseTurn);
				antiClockWiseTurn = CheckWithinAngleRange(antiClockWiseTurn);

				if(clockWiseTurn<antiClockWiseTurn)
				{
					transform.Rotate(0,0,step);
				}
				else
				{
					transform.Rotate(0,0,step*-1);
				}
			}
			else
			{
					//TODO Modiy so cancels out any other forces causing to move in directions other then create for example:
					// currently moving (0,+y) due to force (0,+y)
					// now wants to move (+x,0) with force (+x,0) but moves (+x,+y) because of previous +y force
					// needs to add force (+x,-y) until y movement = (+x,0)
					m_Movement =new Vector3(moveHorizontal,moveVertical); 
					Debug.DrawRay(transform.position, m_Movement*10, Color.red);
					//rigidbody2D.velocity.y

					Vector3 nVelocity = rigidbody2D.velocity.normalized;
					Vector2 ReflectionForce = Vector2.Dot(2*m_Movement,nVelocity)*m_Movement - nVelocity;
					
					Debug.DrawRay(transform.position, ReflectionForce*10, Color.yellow);

					rigidbody2D.AddForce(m_Movement * g_Speed *Time.deltaTime);
					//print ("Force :" + m_Movement );
			}
			//Vector3 turnDirection= transform.eulerAngles - TurnVar;
		}
		//print ("Velocity :" + rigidbody2D.velocity.normalized);
		Debug.DrawRay(transform.position, rigidbody2D.velocity.normalized*10, Color.green);
	}

	float CheckWithinAngleRange(float value)
	{
		if(value<0)
		{
			return value +=360;
		}
		else if (value>360)
		{
			return value -=360;
		}
		else
		return value;
	}
	
	void OnTriggerExit2D(Collider2D hit)
	{
		print("Triggered Exit");
		
		if(hit.gameObject.CompareTag("Planet"))/* == "Planet")*/
		{
			print("Left Planet");
		}
		if(hit.gameObject.tag == "GravityWell")
		{
			print("Left GravityWell");
		}
	}
	void OnTriggerEnter2D(Collider2D hit)
	{
		print("Triggered Entered");
			if(hit.gameObject.CompareTag("Planet"))/* == "Planet")*/
		{
			print("Entered Planet");
		}
	}
}
