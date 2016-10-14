module Strangelights.Samples.Helpers
open System.Web.Security
// give shorte name to password hashing method
let hash = FormsAuthentication.HashPasswordForStoringInConfigFile

