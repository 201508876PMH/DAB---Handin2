--
-- Create Table    : 'Telefonnummer'   
-- telefonnummerID :  
-- personID        :  (references Person.personID)
-- teleselskabID   :  (references Teleselskab.teleselskabID)
-- type            :  
--
CREATE TABLE Telefonnummer (
    telefonnummerID INT NOT NULL,
    personID       INT NOT NULL,
    teleselskabID  INT NOT NULL,
    type           NVARCHAR(15) NOT NULL,
CONSTRAINT pk_Telefonnummer PRIMARY KEY CLUSTERED (telefonnummerID),
CONSTRAINT fk_Telefonnummer FOREIGN KEY (personID)
    REFERENCES Person (personID)
    ON DELETE CASCADE
    ON UPDATE CASCADE,
CONSTRAINT fk_Telefonnummer2 FOREIGN KEY (teleselskabID)
    REFERENCES Teleselskab (teleselskabID)
    ON DELETE NO ACTION
    ON UPDATE CASCADE)