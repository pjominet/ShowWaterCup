(ns app.main
  (:require [app.lib :refer [startGame]]))

(defn reload!
  []
  (println "Code updated!")
  (startGame "drawing1"))

(defn main
  []
  (println "App loaded!")
  (startGame "drawing1" 10 10))
