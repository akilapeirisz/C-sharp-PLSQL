CREATE OR REPLACE TYPE BODY library_db_apeilk_user_type AS

	/* INSERT */
	MEMBER PROCEDURE create_(name_   IN VARCHAR2(100),
													 address IN library_db_apeilk_address_type,
													 email   IN VARCHAR2(100),
													 uname   IN VARCHAR2(50),
													 pass    IN VARCHAR2(50)) IS
	BEGIN
		INSERT INTO library_db_apeilk_user_tab
		VALUES
			(library_db_apeilk_user_seq_.nextval, name_, address, email);
	END create_;

	/* UPDATE */
	MEMBER PROCEDURE update_(us_id_      IN NUMBER,
													 new_name_   IN VARCHAR2(100),
													 new_address IN library_db_apeilk_address_type%TYPE,
													 new_email   IN VARCHAR2(100) uname IN VARCHAR2(50),
													 pass        IN VARCHAR2(50)) IS
	BEGIN
		UPDATE library_db_apeilk_user_tab
			 SET name_ = new_name_, address = new_address, email = new_email
		 WHERE id_ = us_id;
	END update_;

	/* DELETE */
	MEMBER PROCEDURE delete_(id_ IN NUMBER)) IS
	BEGIN
		DELETE FROM library_db_apeilk_user_tab WHERE id_ = us_id;
	END delete_;

	/* SEARCH BY ID */
	MEMBER PROCEDURE get_(us_id_ IN NUMBER,
												data_  OUT library_db_apeilk_user_type%ROWTYPE)) IS
		CURSOR Retrieve_row IS
			SELECT * FROM library_db_apeilk_user_tab WHERE id_ = us_id_;
	BEGIN
		OPEN Retrieve_row;
		FETCH Retrieve_row
			INTO data_;
		CLOSE Retrieve_row;
	END get_;

	/* PRINT RECORDS BY ID */
	MEMBER PROCEDURE display_(id_ IN NUMBER)) IS
	BEGIN
		data_ library_db_apeilk_user_type;
		get_(us_id_, data_);
	END get_;

END;
/* --------------------------------------------------- */
