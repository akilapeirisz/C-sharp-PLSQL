/* CREATE library_db_apeilk_author_type TYPE */
CREATE OR REPLACE TYPE library_db_apeilk_author_type UNDER library_db_apeilk_person_type
(
	MEMBER PROCEDURE create_(name_   IN VARCHAR2,
													 address IN library_db_apeilk_address_type,
													 email   IN VARCHAR2),

	MEMBER PROCEDURE update_(id_     IN NUMBER,
													 name_   IN VARCHAR2,
													 address IN library_db_apeilk_address_type,
													 email   IN VARCHAR2);
	
	MEMBER PROCEDURE delete_(id_ IN NUMBER),

	MEMBER PROCEDURE get_(id_   IN NUMBER,
												data_ OUT library_db_apeilk_author_type),

	MEMBER PROCEDURE display_(id_ IN NUMBER)

)
;
/* --------------------------------------------------- */
