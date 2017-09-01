/* CREATE library_db_apeilk_user_type TYPE */
CREATE OR REPLACE TYPE library_db_apeilk_user_type UNDER library_db_apeilk_person_type
(
	uname   VARCHAR2(50),
	pass   VARCHAR2(50),


	MEMBER PROCEDURE create_(name_   IN VARCHAR2,
													 address IN library_db_apeilk_address_type,
													 email   IN VARCHAR2,
													 uname   IN VARCHAR2(50),
													 pass    IN VARCHAR2(50)),

	MEMBER PROCEDURE update_(id_     IN NUMBER,
													 name_   IN VARCHAR2,
													 address IN library_db_apeilk_address_type,
													 email   IN VARCHAR2,
													 uname   IN VARCHAR2(50),
													 pass    IN VARCHAR2(50)),

	MEMBER PROCEDURE delete_(id_ IN NUMBER),

	MEMBER PROCEDURE get_(id_   IN NUMBER,
												data_ OUT library_db_apeilk_user_type),

	MEMBER PROCEDURE display_(id_ IN NUMBER)
)
;
/* --------------------------------------------------- */
