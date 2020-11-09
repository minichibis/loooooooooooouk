using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TweetManager : MonoBehaviour
{
    [SerializeField] GameObject[] tweets;
	[SerializeField] GameObject tweetDisplay;
	[SerializeField] int deleteTweetsAfter = 5;
	[SerializeField] float spawnTime = 5;
	[SerializeField] string[] tweetMessages;
    public bool spawnTweets = false;

	public void StartSpawnTweets() { spawnTweets = true; StartCoroutine(SpawnTweets()); }

	public IEnumerator SpawnTweets()
	{
		while(spawnTweets)
		{
			yield return new WaitForSeconds(spawnTime);
			GameObject tweet = Instantiate(tweets[Random.Range(0, tweets.Length)], tweetDisplay.transform);
			tweet.GetComponentInChildren<TMP_Text>().text = tweetMessages[Random.Range(0, tweetMessages.Length)];
		}
	}
}
