(ns graphics.grid
  (:require [graphics.canvas :refer [get-canvas get-ctx]]
           [game.board :as b]))

(def fst #(first %))
(def snd #(get % 1))

(defn draw-line
  "input: ctx, start and end point [x y]
   effect: draws the line"
  [c start end]
  (.moveTo c (fst start) (snd start))
  (.lineTo c (fst end) (snd end))
  (.stroke c))

(defn bold-line-width [c] (set! (.-lineWidth c) 10))
(defn medium-line-width [c] (set! (.-lineWidth c) 5))
(defn black [c] (set! (.-fillStyle c) "rgb(255,0,0)"))

(defn draw-lines
  "input: ctx, start iteration and lines vector
   effect: draws all given lines"
  [c iteration linesToDraw]
  (loop [i iteration
         lines linesToDraw]
    (let [line (peek lines)
          a (fst line)
          b (snd line)]
      (draw-line c a b))
    (if (> (count lines) 0)
      (recur (dec i) (pop lines)))))

(defn draw-grid
  "input: ctx, number of rows & cols for grid
   effect: draws the grid on the context"
  [c nRows nCols]
  (let [colW (/ (.-w c) nCols)
        rowH (/ (.-h c) nRows)
        colLines (b/generate-columns c nCols colW)
        rowLines (b/generate-rows c nRows rowH)]

    ; draw axis lines
    (bold-line-width c)
    (black c)
    (draw-line c [0 0] [(.-w c) 0]) ; col
    (draw-line c [0 0] [0 (.-h c)]) ; row

    ; draw cols & rows
    (medium-line-width c)
    (draw-lines c (dec nCols) colLines)
    (draw-lines c (dec nRows) rowLines)))

(defn startGame
  [canvasId nCols nRows]
  (let [canvas (get-canvas canvasId)
        ctx (get-ctx canvas)]
    (set! (.-w ctx) (.-width canvas))
    (set! (.-h ctx) (.-height canvas))
    (.clearRect ctx 0 0 (.-w ctx) (.-h ctx))
    (draw-grid ctx nCols nRows)))
