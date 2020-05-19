package com.periscope.qviz.json;

/**
 * JSON Model for basic Key-Value Pair Details
 */
public class KeyValue {

	/**
	 * Key of the JSON Pair Object
	 */
	public String key;

	/**
	 * Value of the JSON Pair Object
	 */
	public String value;

	/**
	 * Initialize the Key-Value Pair for JSON Object
	 */
	public KeyValue() {
		this.key = "";
		this.value = "";
	}

	/**
	 * Create a new Key-Value Pair with the provided details
	 *
	 * @param key   Key of the JSON Pair Object
	 * @param value Value of the JSON Pair Object
	 */
	public KeyValue(String key, String value) {
		this.key = key;
		this.value = value;
	}

}
