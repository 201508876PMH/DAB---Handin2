--
-- Create Table    : 'Note'   
-- noteID          :  
-- personID        :  (references Person.personID)
-- noteData        :  
--
CREATE TABLE Note (
    noteID         INT IDENTITY(1,1) NOT NULL,
    personID       INT NOT NULL,
    noteData       NVARCHAR(1000) NOT NULL,
CONSTRAINT pk_Note PRIMARY KEY CLUSTERED (noteID),
CONSTRAINT fk_Note FOREIGN KEY (personID)
    REFERENCES Person (personID)
    ON DELETE NO ACTION
    ON UPDATE CASCADE)