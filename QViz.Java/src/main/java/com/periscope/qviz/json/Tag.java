package com.periscope.qviz.json;

/**
 * JSON Model Class for Tag Details
 */
public class Tag {

	/**
	 * Identifier of the Tag
	 */
	public String tagId;

	/**
	 * Name of the Tag
	 */
	public String tagName;

	/**
	 * Default Constructor
	 */
	public Tag() {
		this.tagId = "";
		this.tagName = "";
	}

	/**
	 * Create a new Tag with the provided values
	 *
	 * @param id   Identifier of the Tag
	 * @param name Name of the Tag
	 */
	public Tag(String id, String name) {
		this.tagId = id;
		this.tagName = name;
	}

}
