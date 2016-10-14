module Strangelights.Sample1
// represents an xml attribute
type XmlAttribute =
    { AttribName: string;
      AttribValue: string; }

// represents an xml element
type XmlElement =
    { ElementName: string;
      Attributes: list<XmlAttribute>;
      InnerXml: XmlTree }
      
// represents an XML tree
and XmlTree =
  | Element of XmlElement
  | ElementList of list<XmlTree>
  | Text of string
  | Comment of string 
  | Empty
