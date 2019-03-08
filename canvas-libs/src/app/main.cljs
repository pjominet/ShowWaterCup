(ns app.main
  (:require [graphics.grid :refer [startGame]]))

(defn reload!
  []
  (println "Code updated!")
  (startGame "drawing1" 10 10))

(defn main
  []
  (println "App loaded!")
  (startGame "drawing1" 10 10))
